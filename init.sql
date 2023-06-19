CREATE EXTENSION hstore;

CREATE TABLE public."ForbiddenSeries" (
    "Id" integer NOT NULL,
    "ForbiddenSeriesOfNumbers" text[]
);

CREATE TABLE public."SrnpInfos" (
    "Id" integer NOT NULL,
    "Regex" text,
    "Number" integer NOT NULL,
    "Series" integer NOT NULL,
    "Region" integer NOT NULL,
    "GovCode" integer NOT NULL,
    "Color" text,
    "TypePerson" text[],
    "TechCategory" text[],
    "GrnzType" text[],
    "SrnpCode" text[],
    "SrnpTypeCode" public.hstore,
    "SrnpCount" integer DEFAULT 0 NOT NULL
);

CREATE TABLE public."SrnpPrices" (
    "Id" integer NOT NULL,
    "PriceCategory" integer NOT NULL,
    "Numbers" text[],
    "Price" text,
    "PriceInMci" text,
    "IsSameLetter" boolean NOT NULL
);

INSERT INTO public."ForbiddenSeries" ("Id", "ForbiddenSeriesOfNumbers") VALUES (1, '{KZ,UD,AM,QR,AAM,BOK,CEX,FBP,FBR,HER,KAL,KOT,MAL,OON,SOR,SOP,SOS,SEX,USA,XER,XYE,ZEK,GEI,GEY,GAY,JID,GON,GAD,CON,QUM,GOD,EBI,EPT,IIM,ISK,GOS,IIN,HUI,XUI,HUY,HYI,XUY,QUL,QAN,JUT,QYQ,TYQ,JMI,GAI,VOR,BOP,FUK,FAK,FUC,FAC,LOH,IOX,IOH,COX,KOX,BOQ,SIK,SYK,QOR,QAS,QOI,JOI,LOX,WX,JYN}');

INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (9, '^([DT])([0-9]{3})([0-9]{3})$', 3, 1, 0, 2, 'red', '{Person,Legal}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1Г,2Г}', '{195,295}', '"1Г"=>"195", "2Г"=>"295"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (11, '^(HC)([0-9]{4})$', 2, 1, 0, 0, 'yellow', '{Person}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1Д,2Д}', '{118}', '"1Д"=>"118", "2Д"=>"118"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (14, '^(M)([0-9]{3})([0-9]{3})$', 3, 1, 0, 2, 'yellow', '{Legal}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1Д,2Д}', '{195,295}', '"1Д"=>"195", "2Д"=>"295"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (7, '^([0-9]{3})(0[1-9]|1[0-9]|20)$', 1, 0, 2, 0, 'blue', '{Legal}', '{L3,L4,L5,L6,L7}', '{3С}', '{999}', '"3С"=>"999"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (12, '^(HC)([0-9]{2})$', 2, 1, 0, 0, 'yellow', '{Person}', '{L3,L4,L5,L6,L7}', '{3Д}', NULL, '"3Д"=>NULL', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (13, '^(HC)([0-9]{2})([0-9]{3})$', 2, 1, 0, 3, 'yellow', '{Person}', '{O1,O2,O3,O4}', '{5Д,5ДА}', NULL, '"5Д"=>NULL, "5ДА"=>NULL', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (8, '^([0-9]{2})([A-Z]{2})(0[1-9]|1[0-9]|20)$', 1, 2, 3, 0, 'blue', '{Legal}', '{O1,O2,O3,O4}', '{5С,5СА}', '{595}', '"5С"=>"595", "5СА"=>"595"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (2, '^([0-9]{3})([A-Z]{3})(0[1-9]|1[0-9]|20)$', 1, 2, 3, 0, 'white', '{Person}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1А,2А}', '{120,220}', '"1А"=>"120", "2А"=>"220"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (18, '^([HFCL])([0-9]{2})(0[1-9]|1[0-9]|20)$', 2, 1, 3, 0, 'yellow', '{Person,Legal}', '{L3,L4,L5,L6,L7}', '{3Д}', '{393}', '"3Д"=>"393"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (3, '^([0-9]{2})([A-Z]{2})(0[1-9]|1[0-9]|20)$', 1, 2, 3, 0, 'white', '{Person,Legal}', '{L3,L4,L5,L6,L7}', '{3}', '{395}', '"3"=>"395"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (4, '^([0-9]{2})([A-Z]{3})(0[1-9]|1[0-9]|20)$', 1, 2, 3, 0, 'white', '{Person,Legal}', '{O1,O2,O3,O4}', '{5,5А}', '{501}', '"5"=>"501", "5А"=>"501"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (17, '^([HFCL])([0-9]{4})(0[1-9]|1[0-9]|20)$', 2, 1, 3, 0, 'yellow', '{Person,Legal}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1Д,2Д}', '{195,295}', '"1Д"=>"195", "2Д"=>"295"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (5, '^([AB])([0-9]{4})(0[1-9]|1[0-9]|20)$', 2, 1, 3, 0, 'yellow', '{Legal}', NULL, '{1А-1,1А-2}', '{195,295}', '"1А-1"=>"195", "1А-2"=>"295"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (6, '^([0-9]{4})(0[1-9]|1[0-9]|20)$', 1, 0, 2, 0, 'blue', '{Person}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1С,2С}', '{896}', '"1С"=>"896", "2С"=>"896"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (21, '\bPROTOKOL\b', 0, 0, 0, 0, 'red', NULL, NULL, '{1Г}', NULL, '"1Г"=>NULL', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (20, '^([0-9]{3})([A-Z]{2})$', 1, 2, 0, 0, 'white', NULL, NULL, '{1К}', NULL, '"1К"=>NULL', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (16, '^(M)([0-9]{3})([0-9]{3})$', 2, 1, 0, 3, 'yellow', '{Legal}', '{O1,O2,O3,O4}', '{5Д,5ДА}', '{594}', '"5Д"=>"594", "5ДА"=>"594"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (19, '^([HFCL])([0-9]{3})(0[1-9]|1[0-9]|20)$', 2, 1, 3, 0, 'yellow', '{Person,Legal}', '{O1,O2,O3,O4}', '{5Д,5ДА}', '{594}', '"5Д"=>"594", "5ДА"=>"594"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (1, '^([0-9]{3})([A-Z]{2})(0[1-9]|1[0-9]|20)$', 1, 2, 3, 0, 'white', '{Legal}', '{M1,M1G,M2,M2G,M3,M3G,N1,N1G,N2,N2G,N3,N3G}', '{1,2}', '{119,219}', '"1"=>"119", "2"=>"219"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (10, '^([DT])([0-9]{3})([0-9]{2})$', 3, 1, 0, 2, 'red', '{Person,Legal}', '{L3,L4,L5,L6,L7,O1,O2,O3,O4}', '{3Г,5Г,5ГА}', '{394,594}', '"3Г"=>"394", "5Г"=>"594", "5ГА"=>"594"', 0);
INSERT INTO public."SrnpInfos" ("Id", "Regex", "Number", "Series", "Region", "GovCode", "Color", "TypePerson", "TechCategory", "GrnzType", "SrnpCode", "SrnpTypeCode", "SrnpCount") VALUES (15, '^(M)([0-9]{2})([0-9]{3})$', 2, 1, 0, 3, 'yellow', '{Legal}', '{L3,L4,L5,L6,L7}', '{3Д}', '{394}', '"3Д"=>"394"', 0);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (1, 7, '{001,002,003,004,005,006,007,008,009,777}', '983250 KZT', '285', true);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (2, 6, '{001,002,003,004,005,006,007,008,009,777}', '786600 KZT', '228', false);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (3, 5, '{100,111,200,222,300,333,400,444,500,555,600,666,700,800,888,900,999}', '669300 KZT', '194', true);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (4, 4, '{100,111,200,222,300,333,400,444,500,555,600,666,700,800,888,900,999}', '472650 KZT', '137', false);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (5, 3, '{010,020,030,040,050,060,070,077,080,090,707}', '393300 KZT', '114', true);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (6, 2, '{010,020,030,040,050,060,070,077,080,090,707}', '196650 KZT', '57', false);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (7, 1, NULL, '196650 KZT', '57', true);
INSERT INTO public."SrnpPrices" ("Id", "PriceCategory", "Numbers", "Price", "PriceInMci", "IsSameLetter") VALUES (8, 0, NULL, '9660 KZT', '2.8', false);
