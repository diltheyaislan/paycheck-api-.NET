﻿# Paycheck API

O projeto disponibiliza uma API REST desenvolvida em .NET e permite o cadastro de funcionários e geração do contracheque.

Os dados dos funcionários são persistidos em um banco de dados PostgreSQL. A geração do contracheque tem como data de referência o mês anterior ao mês atual e os dados são gerados em tempo de execução.


URLs da aplicação:
- <https://paycheck-api-dotnet.herokuapp.com/v1> - URL base da API (Heroku)
- <https://hub.docker.com/repository/docker/diltheyaislan/paycheckapi> - Docker

## Pré-requisitos

- Configurar a string de conexão do banco de dados no arquivo `.\PaycheckAPI\appsettings.json` na propriedade `DefaultConnection`
- Excutar o script SQL `employee.sql`


## Iniciar aplicação

No diretório raiz do repositório, executar comando:

`dotnet run --project .\PaycheckAPI\PaycheckAPI.csproj`


## Testes
Foram implementados testes unitários para:

- Serviços de funcionário - Criação e consulta através de um Mock do repositório de funcionários

- Serviços de contracheque - Geração do contracheque e cálculos dos descontos

Para rodar os testes, executar o comando:

`dotnet test`


## Métodos

As requisições devem seguir os padrões:

| Método| Descrição |
| ------ | ------ |
| `GET`| Consulta e retorno de dados de um ou mais registros |
| `POST` | Criação de um novo registro |
| `PATCH` | Atualização parcial de um registro, sem necessidade de envio do payload completo |
| `DELETE` | Remoção de um registro |


## Respostas

| Código| Descrição |
| ------ | ------ |
| `200`| Requisição executada com sucesso (success) |
| `404` | Registro não encontrado (not found) |


## Recursos

### Funcionários [/employees]
Recurso para listar, mostrar, criar, alterar e remover funcionários e retornar dados do contracheque.

### Listar funcionários

* **URL**

  ***[GET]*** `/employees`

* **Resposta de Sucesso**

  Response 200 (application/json) 
  ```sh
  [
    {
      "id": "2e1fde7a-3719-49ed-aabc-978938b8b273",
      "name": "Noah",
      "lastName": "de Paula",
      "document": "124578",
      "department": "IT",
      "grossWage": 5000,
      "admissionDate": "2019-11-06",
      "hasHealthPlan": true,
      "hasDentalPlan": true,
      "hasTransportationVouchersDiscount": true
    }
  ] 
  ```
  Onde:
  - **id** - Identificação em UUID do funcionário
  - **name** - Nome do funcionário
  - **lastName** - Sobrenome do funcionário
  - **document** - Documento do funcionário (RG, CPF)
  - **departament** - Departamento do funcionário
  - **grossWage** - Salário bruto do funcionário
  - **admissionDate** - Data de admissão do funcionário
  - **hasHealthPlan** - Retorna `true` se funcionário tem plano de saúde ou `false` se não
  - **hasDentalPlan** - Retorna `true` se funcionário tem plano odontológico ou `false` se não
  - **hasTransportationVouchersDiscount** - Retorna `true` se funcionário tem vale transporte ou `false` se não
  
### Criar funcionário

* **URL**

  ***[POST]*** `/employees`

* **Requisição**

   Body (application/json) 
   ```sh
   {
     "name": "Noah",
     "lastName": "de Paula",
     "document": "124578",
     "department": "IT",
     "grossWage": 5000,
     "admissionDate": "2019-11-06",
     "hasHealthPlan": true,
     "hasDentalPlan": true,
     "hasTransportationVouchersDiscount": true
   }
 
   ```
  Onde:
  - **name** - Nome do funcionário
  - **lastName** - Sobrenome do funcionário
  - **document** - Documento do funcionário (RG, CPF)
  - **departament** - Departamento do funcionário
  - **grossWage** - Salário bruto do funcionário
  - **admissionDate** - Data de admissão do funcionário
  - **hasHealthPlan** - Informa`true` se funcionário tem plano de saúde ou `false` se não
  - **hasDentalPlan** - Informa `true` se funcionário tem plano odontológico ou `false` se não
  - **hasTransportationVouchersDiscount** - Informa `true` se funcionário tem vale transporte ou `false` se não

* **Resposta de Sucesso**

  Response 200 (application/json) 
  ```sh
  {
    "id": "2e1fde7a-3719-49ed-aabc-978938b8b273",
    "name": "Noah",
    "lastName": "de Paula",
    "document": "124578",
    "department": "IT",
    "grossWage": 5000,
    "admissionDate": "2019-11-06",
    "hasHealthPlan": true,
    "hasDentalPlan": true,
    "hasTransportationVouchersDiscount": true
  }
  ```
  
### Detalhar funcionário

* **URL**

  ***[GET]*** `/employees/{id}`

* **Parâmetros**

   - `id` Código do funcionário

* **Resposta de Sucesso**

  Response 200 (application/json) 
  ```sh
  {
    "id": "2e1fde7a-3719-49ed-aabc-978938b8b273",
    "name": "Noah",
    "lastName": "de Paula",
    "document": "124578",
    "department": "IT",
    "grossWage": 5000,
    "admissionDate": "2019-11-06",
    "hasHealthPlan": true,
    "hasDentalPlan": true,
    "hasTransportationVouchersDiscount": true
  }
  ```

* **Resposta de Erro**

  Response 404 (application/json) 
  ```sh
  {
    "message": "Employee not found"
  }
  ```

### Editar funcionário

* **URL**

  ***[PATCH]*** `/employees/{id}`

* **Parâmetros**

   - `id` Código do funcionário

* **Requisição**

   Body (application/json) - Não é necessário informar todos os atributos
   ```sh
   {
     "name": "Noah",
     "lastName": "de Paula",
     "document": "124578",
     "department": "IT",
     "grossWage": 5000,
     "admissionDate": "2019-11-06",
     "hasHealthPlan": true,
     "hasDentalPlan": true,
     "hasTransportationVouchersDiscount": true
   }
 
   ```
  Onde:
  - **name** - Nome do funcionário
  - **lastName** - Sobrenome do funcionário
  - **document** - Documento do funcionário (RG, CPF)
  - **departament** - Departamento do funcionário
  - **grossWage** - Salário bruto do funcionário
  - **admissionDate** - Data de admissão do funcionário
  - **hasHealthPlan** - Informa`true` se funcionário tem plano de saúde ou `false` se não
  - **hasDentalPlan** - Informa `true` se funcionário tem plano odontológico ou `false` se não
  - **hasTransportationVouchersDiscount** - Informa `true` se funcionário tem vale transporte ou `false` se não

* **Resposta de Sucesso**

  Response 200 (application/json) 
  ```sh
  {
    "id": "2e1fde7a-3719-49ed-aabc-978938b8b273",
    "name": "Noah",
    "lastName": "de Paula",
    "document": "124578",
    "department": "IT",
    "grossWage": 5000,
    "admissionDate": "2019-11-06",
    "hasHealthPlan": true,
    "hasDentalPlan": true,
    "hasTransportationVouchersDiscount": true
  }
  ```

* **Resposta de Erro**

  Response 404 (application/json) 
  ```sh
  {
    "message": "Employee not found"
  }
  ```

### Remover funcionário

* **URL**

  ***[DELETE]*** `/employees/{id}`

* **Parâmetros**

   - `id` Código do funcionário

* **Resposta de Sucesso**

  Response 200 - No body

* **Resposta de Erro**

  Response 404 (application/json) 
  ```sh
  {
    "message": "Employee not found"
  }
  ```

### Contracheque

* **URL**

  ***[GET]*** `/employees/{id}/paycheck`

* **Parâmetros**

   - `id` Código do funcionário

* **Resposta de Sucesso**

  Response 200 (application/json) 
  ```sh
  {
    "referencePeriod": "01/2021",
    "grossSalary": 7000,
    "netSalary": 5135.64,
    "totalDiscounts": -1864.36,
    "entries": [
      {
        "type": "Remunaration",
        "amount": 7000,
        "description": "Salary"
      },
      {
        "type": "Discount",
        "amount": 869.36,
        "description": "IRPF"
      },
      {
        "type": "Discount",
        "amount": 560,
        "description": "FGTS"
      },
      {
        "type": "Discount",
        "amount": 10,
        "description": "Health plan"
      },
      {
        "type": "Discount",
        "amount": 5,
        "description": "Dental plan"
      },
      {
        "type": "Discount",
        "amount": 420,
        "description": "Transportation voucher"
      }
    ]
  }
  ```

  Onde:
  - **referencePeriod** - Período de referência do contracheque (MM/YYYY)
  - **grossSalary** - Valor do salário bruto
  - **netSalary** - Valor do salário líquido
  - **totalDiscounts** - Valor total de descontos
  - **entries** - Lista de lançamentos
  - **entries.type** - Tipo do lançamento
  - **entries.amount** - Valor do lançamento
  - **entries.description** - Descrição do lançamento

* **Resposta de Erro**

  Response 404 (application/json) 
  ```sh
  {
    "message": "Employee not found"
  }
  ```
