CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Challenges" (
    "Id" character varying(200) NOT NULL,
    "Duration" integer NOT NULL,
    "MonthlyIncome" numeric NOT NULL,
    "ProductType" integer NOT NULL,
    "IncomePercentage" double precision NOT NULL,
    "ChallengeAccepted" boolean NOT NULL,
    "Name" character varying(150) NOT NULL,
    "Description" character varying(150) NOT NULL,
    "InterestRate" double precision NOT NULL,
    "Amount" numeric NOT NULL,
    "EstimatedInterest" numeric NOT NULL,
    "StartDate" timestamp with time zone NOT NULL,
    "WithdrawalDate" timestamp with time zone NOT NULL,
    "UserId" text NOT NULL,
    "CowryWiseId" text NOT NULL,
    "CowryWiseProductId" text NOT NULL,
    "TargetAmount" numeric NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Challenges" PRIMARY KEY ("Id")
);

CREATE TABLE "Savings" (
    "Id" character varying(200) NOT NULL,
    "ProductType" integer NOT NULL,
    "SavingsFrequency" integer NOT NULL,
    "Name" character varying(150) NOT NULL,
    "Description" character varying(150) NOT NULL,
    "InterestRate" double precision NOT NULL,
    "Amount" numeric NOT NULL,
    "EstimatedInterest" numeric NOT NULL,
    "StartDate" timestamp with time zone NOT NULL,
    "WithdrawalDate" timestamp with time zone NOT NULL,
    "UserId" text NOT NULL,
    "CowryWiseId" text NOT NULL,
    "CowryWiseProductId" text NOT NULL,
    "TargetAmount" numeric NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Savings" PRIMARY KEY ("Id")
);

CREATE TABLE "Stashes" (
    "Id" character varying(200) NOT NULL,
    "Duration" integer NOT NULL,
    "ProductType" integer NOT NULL,
    "Name" character varying(150) NOT NULL,
    "Description" character varying(150) NOT NULL,
    "InterestRate" double precision NOT NULL,
    "Amount" numeric NOT NULL,
    "EstimatedInterest" numeric NOT NULL,
    "StartDate" timestamp with time zone NOT NULL,
    "WithdrawalDate" timestamp with time zone NOT NULL,
    "UserId" text NOT NULL,
    "CowryWiseId" text NOT NULL,
    "CowryWiseProductId" text NOT NULL,
    "TargetAmount" numeric NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Stashes" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211119082244_ApidbInit', '6.0.0');

COMMIT;

