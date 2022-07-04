-- CREATE TABLE council_tax_search (
--                         account_ref int,
--                         account_cd varchar,
--                         lead_liab_name varchar,
--                         lead_liab_title varchar,
--                         lead_liab_forename varchar,
--                         lead_liab_surname varchar,
--                         addr1 varchar,
--                         addr2 varchar,
--                         addr3 varchar,
--                         addr4 varchar,
--                         postcode varchar
-- );

---ACADEMY COUNCIL TAX---

CREATE TABLE [ctaccount] (
  [account_ref] int,
  [account_cd] nvarchar(1),
  [lead_liab_title] nvarchar(8),
  [lead_liab_name] nvarchar(32),
  [lead_liab_forename] nvarchar(32),
  [lead_liab_surname] nvarchar(32),
  [addr1] nvarchar(32),
  [addr2] nvarchar(32),
  [addr3] nvarchar(32),
  [addr4] nvarchar(32),
  [postcode] nvarchar(8),
  [paymeth_code] nvarchar(5)
  );


insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (815631207, '5', 'Ms', 'COOKE,MS NADY', 'Nady', 'Cooke','6 Cascade Junction', '49','Norway Maple Pass', 'LONDON', 'I3 0RP', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (2566443, '4', 'mr', 'BULLIMORE,MR TATE', 'Tate', 'Bullimore','8 Schlimgen Terrace', '5111', 'Basil Avenue', 'LONDON', 'E0 1MO', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (27126442, '1', 'Ms', 'MONCUR,MS ELWIRA', 'Elwira', 'Moncur','8017 Garrison Point', '2', 'Lake View Crossing', 'LONDON', 'S3 1EV', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (35205909, '9', 'Mrs', 'OLLIVIER,MRS VAL', 'Val', 'Ollivier','320 Little Fleur Way', '62', 'Warrior Avenue', 'LONDON', 'L0 3DM', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (652268349, '2', 'Rev', 'PISCOPO,REV CLEMENTINA', 'Clementina', 'Piscopo','07 Orin Lane', '73', 'Steensland Terrace', 'LONDON', 'H5 2HM', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (524457367, '6', 'Ms', 'ROSCRIGG,MS ALF', 'Alf', 'Roscrigg','2499 Toban Drive', '40 Butterfield', 'Junction', 'LONDON', 'T6 2KQ', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (3472806, '5', 'Mr', 'GOULBOURN,MR WORTHY', 'Worthy', 'Goulbourn','6037 Dexter Way', '1', 'Sommers Way', 'LONDON', 'H5 7ZN', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (4392512, '6', 'Ms', 'LAURENTINO,MS EVIE', 'Evie', 'Laurentino','4065 Debs Hill', '8491', 'John Wall Plaza', 'LONDON', 'R1 1GT', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (3383987, '5', 'Mr', 'MCKEAG,MR PHILLIDA', 'Phillida', 'McKeag','540 Pawling Street', '063', 'Mitchell Way', 'LONDON', 'U9 1CX', 'CASHM');
insert into ctaccount (account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, addr1, addr2, addr3, addr4, postcode, paymeth_code) values (4599257, '0', 'Ms', 'KILLIGREW,MS PREN', 'Pren', 'Killigrew','0 Clemons Place', '93931', 'Norway Maple Street', 'LONDON', 'F6 5QI', 'CASHM');


CREATE TABLE [ctproperty] (
  [property_ref] nvarchar(18),
  [addr1] nvarchar(35),
  [addr2] nvarchar(35),
  [addr3] nvarchar(32),
  [addr4] nvarchar(32),
  [postcode] nvarchar(8)
  );

insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('109262008', '5 Northfield Park', '58 Muir Plaza','LONDON', 'T9 7KR');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('680348096', '50884 Westridge Road', '79 Talisman Point', 'LONDON','G6 7UB');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('109575307', '0 Claremont Alley', '6906 Northwestern Avenue', 'LONDON','I0 5XL');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('267583903', '92548 Kensington Junction', '090 Dixon Junction', 'LONDON','N9 8CK');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('149325830', '509 Cherokee Pass', '57 Truax Parkway', 'LONDON','T0 0TF');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('648485095', '25 Maple Wood Park', '3 Prairie Rose Alley', 'LONDON','Q0 0ZE');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('574217061', '0 Sauthoff Plaza', '10552 Hollow Ridge Center', 'LONDON','F4 4NM');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('119594222', '3105 West Road', '55 John Wall Parkway', 'LONDON','J6 2OK');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('829925393', '6 Killdeer Avenue', '4276 American Ash Terrace', 'LONDON','L8 5ZB');
insert into ctproperty (property_ref, addr1, addr2, addr3, postcode) values ('662772030', '70 Dottie Place', '48 Golf View Way', 'LONDON','B1 8VV');

CREATE TABLE [hbctaxclaim] (
  [claim_id] int,
  [ctax_claim_id] smallint,
  [ctax_ref] nvarchar(9)
  );

insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (7368451, 3, '81563120');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (5759744, 1, '25664434');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (5260765, 1, '271264421');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (2866464, 6, '35200939');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (9359082, 8, '65683492');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (8722915, 1, '5573676');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (2743325, 3, '21264421');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (3581194, 7, '5269188');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (8903330, 1, '4069341');
insert into hbctaxclaim (claim_id, ctax_claim_id, ctax_ref) values (3690439, 4, '9702729');

CREATE TABLE [ctoccupation] (
  [account_ref] int,
  [property_ref] nvarchar(18),
  [vacation_date] datetime
  );

insert into ctoccupation (account_ref, property_ref, vacation_date) values (815631207, '109262008', '2020-01-02');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (2566443, '680348096', '2017-09-11');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (27126442, '109575307', '2017-10-04');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (35205909, '267583903', '2017-08-28');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (652268349, '149325830', '2017-06-02');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (524457367, '648485095', '2019-05-01');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (205020645, '171903858', '2018-11-01');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (107807366, '247646667', '2018-12-07');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (864594800, '301103337', '2019-02-28');
insert into ctoccupation (account_ref, property_ref, vacation_date) values (998885383, '953980029', '2018-04-15');
-------------

---ACADEMY HOUSING BENEFITS---

CREATE TABLE [hbclaim] (
  [claim_id] int,
  [check_digit] nvarchar(1),
  [status_ind] int,
  [notes_db_handle] nvarchar(14)
  );

insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5260765, '6', 1, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5759744, '0', 2, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (6060591, '3', 3, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5479047, '8', 4, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5879391, '3', 5, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (6115325, '5', 6, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5587103, '4', 7, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5315153, '5', 8, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5167284, '3', 9, '11111111111111');
insert into hbclaim (claim_id, check_digit, status_ind, notes_db_handle) values (5448076, '2', 0, '11111111111111');

CREATE TABLE [hbmember] (
  [claim_id] int,
  [house_id] smallint,
  [person_ref] int,
  [surname] nvarchar(32),
  [forename] nvarchar(32),
  [birth_date] datetime2(7),
  [nino] nvarchar(10),
  [title] nvarchar(4)
  );

insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (5260765, 1, 1, 'Moncur', 'Elwira', '1971-12-22', 'CD877332Z', 'Ms');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (5759744, 1, 1, 'Bullimore', 'Tate', '1971-09-25', 'CD877534Z', 'Ms');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (6060591, 2, 2, 'Beden', 'Flor', '1981-02-08', 'CD877342Z', 'Mr');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (5479047, 1, 1, 'Veare', 'Arlette', '1986-11-07', 'CD657332Z', 'Mr');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (5879391, 3, 3, 'Manoelli', 'Nanny', '1987-05-22', 'CF877332Z', 'Ms');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (6115325, 3, 3, 'Wegener', 'Tera', '1969-08-09', 'CD877332O', 'Mr');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (6233154, 17, 2, 'Wherrett', 'Ruggiero', '1989-08-07', 'CD877355Z', 'Mr');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (6534331, 11, 1, 'Metzing', 'Adara', '1949-12-29', 'CD877334E', 'Mrs');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (6111340, 5, 3, 'Swettenham', 'Babara', '1941-08-05', 'FF577332Z', 'Miss');
insert into hbmember (claim_id, house_id, person_ref, surname, forename, birth_date, nino, title) values (5932526, 11, 1, 'Bourthouloume', 'Damaris', '1944-10-03', 'CE354652Z', 'Mr');

CREATE TABLE [hbhousehold] (
  [claim_id] int,
  [house_id] smallint,
  [to_date] datetime2(7),
  [addr1] nvarchar(35),
  [addr2] nvarchar(35),
  [addr3] nvarchar(32),
  [addr4] nvarchar(32),
  [post_code] nvarchar(10)
  );

insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (5260765, 1, '2099-12-31', '6 Cascade Junction', '49 Norway Maple Pass', 'LONDON', 'I3 0RP');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (5759744, 1, '2099-12-31', '8 Schlimgen Terrace', '5111 Basil Avenue', 'LONDON', 'E0 1MO');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (6060591, 2, '2099-12-31', '8017 Garrison Point', '2 Lake View Crossing', 'LONDON', 'S3 1EV');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (5479047, 1, '2099-12-31', '320 Little Fleur Way', '62 Warrior Avenue', 'LONDON', 'L0 3DM');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (5879391, 3, '2099-12-31', '07 Orin Lane', '73 Steensland Terrace', 'LONDON', 'H5 2HM');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (6115325, 3, '2099-12-31', '2499 Toban Drive', '40 Butterfield Junction', 'LONDON', 'T6 2KQ');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (5696752, 12, '2019-07-14', '6037 Dexter Way', '1 Sommers Way', 'LONDON', 'H5 7ZN');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (6908963, 18, '2019-09-05', '4065 Debs Hill', '8491 John Wall Plaza', 'LONDON', 'R1 1GT');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (6724267, 9, '2019-05-01', '540 Pawling Street', '063 Mitchell Way', 'LONDON', 'U9 1CX');
insert into hbhousehold (claim_id, house_id, to_date, addr1, addr2, addr3, post_code) values (6969380, 20, '2019-04-28', '0 Clemons Place', '93931 Norway Maple Street', 'LONDON', 'F6 5QI');
