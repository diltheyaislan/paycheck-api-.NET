CREATE TABLE "Employees" (
	"Id" uuid NOT NULL,
	"name" text NOT NULL,
	"lastName" text NOT NULL,
	"document" text NOT NULL,
	"department" text NOT NULL,
	"grossWage" numeric NOT NULL,
	"admissionDate" timestamp NOT NULL,
	"hasHealthPlan" bool NOT NULL,
	"hasDentalPlan" bool NOT NULL,
	"hasTransportationVouchersDiscount" bool NOT NULL,
	CONSTRAINT "PK_Employees" PRIMARY KEY ("Id")
);