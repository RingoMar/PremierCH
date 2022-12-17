-- Injected data

INSERT INTO users VALUES ('dev@dev', 'dev', 300, 010);

INSERT INTO STAFF VALUES (300, 'Dev Developer', 'M', 'PHD', '727-4000');
Insert into PATIENT (FNAME,LNAME,CONTACT,PID,GENDER,ADRESS,PDETAILS,BLOODGROUP,SERVICEID,BILLID) values ('Dev','Loper',8049948388,10,'M','4977 Eden Drive

Dawn, Virginia(VA), 230694977 Eden Drive

Dawn, Virginia(VA), 23069','Manic Depressive','O',null,null);

INSERT INTO SERVICE VALUES (1, 'pediatrics');
INSERT INTO SERVICE VALUES (2, 'general practice');
INSERT INTO SERVICE VALUES (3, 'specialist');
INSERT INTO SERVICE VALUES (4, 'laboratory');
INSERT INTO SERVICE VALUES (5, 'therapy');
INSERT INTO SERVICE VALUES (6, 'x-ray');

INSERT INTO room VALUES (1, 'pediatrics');
INSERT INTO room VALUES (2, 'general practice');
INSERT INTO room VALUES (3, 'specialist');
INSERT INTO room VALUES (4, 'laboratory');
INSERT INTO room VALUES (5, 'therapy');
INSERT INTO room VALUES (6, 'x-ray');


INSERT INTO PATIENT VALUES ('Rick', 'Martin', 12345678911, 020, 'M', '#3 Paid street, Long road', 'Patient has long lasting headace', 'AB', null, null);
INSERT INTO PATIENT VALUES ('Bate', 'Taer', 12345678911, 021, 'F', 'Liver Dale ring role', 'Suffers from PCOS', 'A', null, null);
Insert into PATIENT (FNAME,LNAME,CONTACT,PID,GENDER,ADRESS,PDETAILS,BLOODGROUP,SERVICEID,BILLID) values ('Alex','Martin',8572847,2,'M','32 mal street walkers dale ','Has  lung cancer','AB',null,21);
Insert into PATIENT (FNAME,LNAME,CONTACT,PID,GENDER,ADRESS,PDETAILS,BLOODGROUP,SERVICEID,BILLID) values ('John','Dooe',123456,22,'M','#1 home','Problems','A',null,null);
Insert into PATIENT (FNAME,LNAME,CONTACT,PID,GENDER,ADRESS,PDETAILS,BLOODGROUP,SERVICEID,BILLID) values ('adfsdf','dsafdsf',12312312,1,'M','fasdfsdfsdfsdfsdfdsfsdfsdfdsfsd','sdfsdfdsfadsfdsafdfasdfdfadf','AB',null,null);


INSERT INTO APPOINTMENT VALUES ('10', SYSDATE, appointnum.nextval, '3', '301', '3', null)
INSERT INTO RECORD (PID, RECORD_#, APP_ID ) VALUES (021, 0400, 001);

Insert into BILL (BILLID,NAME,COST) values (1,'general practice',1000);
Insert into BILL (BILLID,NAME,COST) values (8,'pediatrics',1000);
Insert into BILL (BILLID,NAME,COST) values (21,'x-ray',1000);
Insert into BILL (BILLID,NAME,COST) values (5,'x-ray',1000);
Insert into BILL (BILLID,NAME,COST) values (9,'general practice',1000);
Insert into BILL (BILLID,NAME,COST) values (3,'general practice',1000);
Insert into BILL (BILLID,NAME,COST) values (4,'general practice',1000);
Insert into BILL (BILLID,NAME,COST) values (6,'laboratory',1000);
Insert into BILL (BILLID,NAME,COST) values (7,'pediatrics',1000);