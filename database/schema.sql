
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
  [for_addr1] nvarchar(32),
  [for_addr2] nvarchar(32),
  [for_addr3] nvarchar(32),
  [for_addr4] nvarchar(32),
  [for_postcode] nvarchar(8),
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

CREATE TABLE [ctnotice] (
  [account_ref] int,
    [bill_no] smallint,
    [bill_adjust] smallint,
    [notice_type] numeric(3),
    [property_ref] varchar(18),
    [notice_from] datetime2,
    [notice_to] datetime2,
    [notice_issued] datetime2,
    [paymeth_code] char(5),
    [paymeth_type] numeric(3),
    [inhibit_cred_tfr] numeric(3),
    [reason] numeric(3),
    [reason1] numeric(3),
    [reason2] numeric(3),
    [reason3] numeric(3),
    [amt_benefit] numeric(14,2),
    [amt_costs] numeric(14,2),
    [amt_debit] numeric(14,2),
    [amt_penalties] numeric(14,2),
    [amt_refunds] numeric(14,2),
    [amt_remit] numeric(14,2),
    [amt_transitional] numeric(14,2),
    [amt_write_off] numeric(14,2),
    [amt_lump_disc] numeric(14,2),
    [amt_paym_disc] numeric(14,2),
    [amt_water] numeric(14,2),
    [amt_water_disab_redn] numeric(14,2),
    [amt_water_disc] numeric(14,2),
    [amt_sewerage] numeric(14,2),
    [amt_sewerage_disab_redn] numeric(14,2),
    [amt_sewerage_disc] numeric(14,2),
    [amt_sewerage_transit] numeric(14,2),
    [notice_balance] numeric(14,2),
    [notice_text] varchar(40),
    [notice_request] numeric(3),
    [notice_request_date] datetime2,
    [vouchers_request] numeric(3),
    [vouchers_issued] datetime2,
    [live_ind] numeric(3),
    [notice_hold] numeric(3),
    [notice_hold_date] datetime2,
    [last_updated_int] int,
    [woff_reason_code] varchar(2),
    [dd_adjust_hold] datetime2

);

insert into dbo.ctnotice (account_ref, bill_no, bill_adjust, notice_type, property_ref, notice_from, notice_to, notice_issued, paymeth_code, paymeth_type, inhibit_cred_tfr, reason, reason1, reason2, reason3, amt_benefit, amt_costs, amt_debit, amt_penalties, amt_refunds, amt_remit, amt_transitional, amt_write_off, amt_lump_disc, amt_paym_disc, amt_water, amt_water_disab_redn, amt_water_disc, amt_sewerage, amt_sewerage_disab_redn, amt_sewerage_disc, amt_sewerage_transit, notice_balance, notice_text, notice_request, notice_request_date, vouchers_request, vouchers_issued, live_ind, notice_hold, notice_hold_date, last_updated_int, woff_reason_code, dd_adjust_hold) values (815631207, 1, 0, 1, N'109262008', N'2021-01-30 00:00:00.0000000', N'2021-04-01 00:00:00.0000000', N'2022-04-01 00:00:00.0000000', N'ARRG ', 2, 0, 2, 0, 0, 0, 0.00, 0.00, 224.57, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 224.57, N'', 0, null, 0, null, 1, 0, null, 1017586620, N'', null);
insert into dbo.ctnotice (account_ref, bill_no, bill_adjust, notice_type, property_ref, notice_from, notice_to, notice_issued, paymeth_code, paymeth_type, inhibit_cred_tfr, reason, reason1, reason2, reason3, amt_benefit, amt_costs, amt_debit, amt_penalties, amt_refunds, amt_remit, amt_transitional, amt_write_off, amt_lump_disc, amt_paym_disc, amt_water, amt_water_disab_redn, amt_water_disc, amt_sewerage, amt_sewerage_disab_redn, amt_sewerage_disc, amt_sewerage_transit, notice_balance, notice_text, notice_request, notice_request_date, vouchers_request, vouchers_issued, live_ind, notice_hold, notice_hold_date, last_updated_int, woff_reason_code, dd_adjust_hold) values (815631207, 2, 0, 1, N'109262008', N'2021-04-01 00:00:00.0000000', N'2022-04-01 00:00:00.0000000', N'2022-04-01 00:00:00.0000000', N'ARRG ', 2, 0, 2, 0, 0, 0, 0.00, 0.00, 1424.11, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 923.43, N'', 0, null, 0, null, 1, 0, null, 1017586620, N'', null);
insert into dbo.ctnotice (account_ref, bill_no, bill_adjust, notice_type, property_ref, notice_from, notice_to, notice_issued, paymeth_code, paymeth_type, inhibit_cred_tfr, reason, reason1, reason2, reason3, amt_benefit, amt_costs, amt_debit, amt_penalties, amt_refunds, amt_remit, amt_transitional, amt_write_off, amt_lump_disc, amt_paym_disc, amt_water, amt_water_disab_redn, amt_water_disc, amt_sewerage, amt_sewerage_disab_redn, amt_sewerage_disc, amt_sewerage_transit, notice_balance, notice_text, notice_request, notice_request_date, vouchers_request, vouchers_issued, live_ind, notice_hold, notice_hold_date, last_updated_int, woff_reason_code, dd_adjust_hold) values (815631207, 3, 0, 1, N'109262008', N'2022-04-01 00:00:00.0000000', N'2023-04-01 00:00:00.0000000', N'2022-04-01 00:00:00.0000000', N'DD01 ', 2, 0, 2, 0, 0, 0, 0.00, 0.00, 1485.42, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1080.00, N'', 0, null, 0, null, 1, 0, null, 1017586522, N'', null);

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

CREATE TABLE [ctnotes_so] (
  [string_id] int,
  [row_sequence] int,
  [text_total] int,
  [text_value] nvarchar(1786),
  );


insert into ctnotes_so (string_id, row_sequence, text_total, text_value)
values  (1091665, 1, 438, N'spd awarded from 15/7/21 sole occupier as per tel cal received.
User Id: jisrael Date: 30.03.2022 11:57:36
--------------------------------------------------------------------------------
Move In Notes FLAT B, 24 BARNABAS ROAD
Acct created in new tenants name wef 15.7.2021 - See LL COA form received on 22.11.2021
User Id: yyasin Date: 21.12.2021 17:30:41
--------------------------------------------------------------------------------
');
insert into ctnotes_so (string_id, row_sequence, text_total, text_value)
values  (218415, 1, 712, N'ms rosenburg set up as per ctb memo...ni
User id : OIBITOYE Date : 12.12.2000
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- TAX PAYER CALLED SHOULD BE GETTING FULL H/B HAVE ADVISED TO SPEAK TO H/BENEFIT....FERNANDA 12/9/2002
User id : FTOUSSAI Date : 12.09.2002

TC FRM TP STATES AWAITING CTB, ADV. WILL CANX SUMMONS ONCE CTB AWARDED
User Id: skerr  Date: 09.09.2003 16:57:03
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
');
insert into ctnotes_so (string_id, row_sequence, text_total, text_value)
values  (482825, 1, 1008, N'balance check
User id : OIBITOYE Date : 12.12.2000
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- TAX PAYER CALLED SHOULD BE GETTING FULL H/B HAVE ADVISED TO SPEAK TO H/BENEFIT....FERNANDA 12/9/2002
No further action necessary
CTB now in payment on 306744352
User Id: hedwards  Date: 30.07.2004 12:10:24
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
');

CREATE TABLE [ctnotepad] (
  [account_ref] int,
  [user_id] nvarchar(8),
  [notes_db_handle] nvarchar(76),
  );
insert into ctnotepad (account_ref, user_id, notes_db_handle) values  (31257355, N'Testy McTestface', N'ctnotes_so:1091665');

insert into ctnotepad (account_ref, user_id, notes_db_handle)
values  (30532993, N'VHILL', N'ctnotes_so:218415'),
        (30532993, N'hedwards', N'ctnotes_so:482825');

CREATE TABLE [hbdiary] (
   [division_id] smallint,
   [code] nvarchar(2),
   [last_upd] int,
   [descrip] nvarchar(30)
);

insert into hbdiary (division_id, code, last_upd, descrip)
values  (1, N'', 185123079, N''),
        (1, N'01', 164336695, N'Referral for next 12 months'),
        (1, N'02', 249489067, N'Change of Circumstances'),
        (1, N'03', 390394930, N'Claim pending'),
        (1, N'04', 390394923, N'WFTC'),
        (1, N'05', 185123079, N'Income Support'),
        (1, N'06', 185123079, N'Rent Increase'),
        (1, N'07', 410801286, N'Manual Adjustment'),
        (1, N'08', 410801349, N'Claimant in Hospital'),
        (1, N'09', 410801628, N'Non-dependent CoC''s'),
        (1, N'10', 410801514, N'Payment on Account'),
        (1, N'11', 410801547, N'Rent Officer Indicative'),
        (1, N'12', 410801583, N'Review Visit'),
        (1, N'13', 410801595, N'Visit'),
        (1, N'14', 410801690, N'General'),
        (1, N'15', 410801706, N'Suspension'),
        (1, N'16', 410801748, N'Supported Accommodation'),
        (1, N'17', 410801802, N'Claimant CoC''s'),
        (1, N'18', 410801837, N'JSA(C) ends'),
        (1, N'19', 418063191, N'Child Benefit check');

CREATE TABLE [hbclaimdiary] (
   [claim_id] int,
   [diary_id] int,
   [diary_code] nvarchar(2),
   [diary_date] datetime2,
   [diary_notes_handle] nvarchar(76),
   [diary_status] numeric(3),
   [job_id] int,
   [user_id] nvarchar(8),
   [report_date] datetime2,
   [last_upd] int,
   [diary_set] datetime2,
   [task_id] int,
   [frequency] int,
   [fa_hb_diary_ind] numeric(2)
);

INSERT INTO hbclaimdiary (claim_id, diary_id, diary_code, diary_date, diary_notes_handle, diary_status, job_id, user_id, report_date, last_upd, diary_set, task_id, frequency, fa_hb_diary_ind) VALUES (5448076, 1869, N'14', N'2005-03-31 00:00:00.0000000', N'hbclaimnotes:67788', 0, 0, N'gziregbe', null, 474466942, N'2005-01-13 00:00:00.0000000', 177, 0, 0);
INSERT INTO hbclaimdiary (claim_id, diary_id, diary_code, diary_date, diary_notes_handle, diary_status, job_id, user_id, report_date, last_upd, diary_set, task_id, frequency, fa_hb_diary_ind) VALUES (5448076, 1869, N'13', N'2005-03-31 00:00:00.0000000', N'hbclaimnotes:816843', 0, 0, N'soluwole', null, 474466942, N'2005-01-13 00:00:00.0000000', 177, 0, 0);

CREATE TABLE [hbclaimnotes] (
  [string_id] int,
  [row_sequence] int,
  [text_total] int,
  [text_value] nvarchar(1786)
);

INSERT INTO hbclaimnotes (string_id, row_sequence, text_total, text_value) VALUES (67788, 1, 15435, N'User Id: gziregbe  Date: 31.03.2022 15:39:37  1017585577
HB and CTS assessed from 13/12/21
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
User Id: pthomas  Date: 16.02.2022 12:35:23  1013862923
TC from partner to check on coa sent in on ref JTVNNZJV, advised not yet and have also advised to provide his new TA and proof of the change in earnings as stated on form this has changed. Also advised will also need to send in last 2 monthly b/s. Clmt has requested a HSC app and this has been done. Also advised clmt that will have to make a claim for CTS as can ');
INSERT INTO hbclaimnotes (string_id, row_sequence, text_total, text_value) VALUES (67788, 2, 15435, N'see this has never been paid.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------');

INSERT INTO hbclaimnotes (string_id, row_sequence, text_total, text_value) VALUES (816843, 1, 258, N'User Id: soluwole  Date: 13.01.2005 12:13:54  474466942

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
');
