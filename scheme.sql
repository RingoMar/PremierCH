
ALTER SESSION SET CONTAINER = XEPDB1;

ALTER DATABASE OPEN;
DROP USER premierch CASCADE;

CREATE USER premierch IDENTIFIED BY premierch;

ALTER USER premierch DEFAULT TABLESPACE users QUOTA UNLIMITED ON users;

ALTER USER premierch TEMPORARY TABLESPACE TEMP;

GRANT CONNECT TO premierch;

GRANT CREATE SESSION, CREATE VIEW, CREATE TABLE, ALTER SESSION, CREATE SEQUENCE TO premierch;
GRANT CREATE SYNONYM, CREATE DATABASE LINK, RESOURCE, UNLIMITED TABLESPACE TO premierch;