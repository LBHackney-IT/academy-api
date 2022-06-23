CREATE VIEW [core].[ctaccount] AS SELECT * FROM  OPENQUERY(LBHATESTHBCT, 'select * from aisdba.ctaccount')
go

INSERT INTO core.ctaccount (division_id, account_ref, account_cd, lead_liab_name, lead_liab_pos, for_addr1, for_addr2, for_addr3, for_addr4, for_postcode, for_district, paymeth_code, paymeth_type, prev_paymeth, prev_paymeth_type, employee_ind, employee_no, swipe_issue_date, swipe_card_request, hb_sar, fast_track, equal_access_code, sched_code, person_status, transmission_date, lead_liab_title, lead_liab_forename, lead_liab_middlename, lead_liab_surname, lead_consent_ind, for_addr_last_updated, hb_archive_ind, party_ref, for_addr_verified, last_updated_int, prohibit_code, prohibit_end, prohibit_set, prohibit_user, prohibit_online_spd, for_addr_abroad, documerge_excl_ind, vulnerable_ind, prohibit_autorefund, suppress_spd_ver, suppress_user, suppress_date, prohibit_dd_over_web, prohibit_auto_move, prohibit_prov_arrg, vulnerable_cust) VALUES (1, 30000003, N'9', N'COOK,MR ROGER', 8, N'44 JUDGE STREET,', N'WATFORD,', N'HERTFORDSHIRE', N'', N'WD2 5AW', N'', N'CASHM', 1, N'     ', 2, 0, N'            ', null, 0, 0, 0, N'', N'', N'', null, N'Mr', N'ROGER', N'', N'COOK', 0, 0, 0, 10000004, 0, 841328525, N'', null, null, N'', 0, 0, 0, 0, 0, 0, N'', null, 0, 0, 0, 0);
INSERT INTO core.ctaccount (division_id, account_ref, account_cd, lead_liab_name, lead_liab_pos, for_addr1, for_addr2, for_addr3, for_addr4, for_postcode, for_district, paymeth_code, paymeth_type, prev_paymeth, prev_paymeth_type, employee_ind, employee_no, swipe_issue_date, swipe_card_request, hb_sar, fast_track, equal_access_code, sched_code, person_status, transmission_date, lead_liab_title, lead_liab_forename, lead_liab_middlename, lead_liab_surname, lead_consent_ind, for_addr_last_updated, hb_archive_ind, party_ref, for_addr_verified, last_updated_int, prohibit_code, prohibit_end, prohibit_set, prohibit_user, prohibit_online_spd, for_addr_abroad, documerge_excl_ind, vulnerable_ind, prohibit_autorefund, suppress_spd_ver, suppress_user, suppress_date, prohibit_dd_over_web, prohibit_auto_move, prohibit_prov_arrg, vulnerable_cust) VALUES (1, 30403567, N'9', N'COOK,MR ROGER', 8, N'44 JUDGE STREET,', N'WATFORD,', N'HERTFORDSHIRE', N'', N'WD2 5AW', N'', N'DD01 ', 2, N'CASHM', 1, 0, N'            ', null, 0, 0, 0, N'', N'', N'', null, N'Mr', N'ROGER', N'', N'COOK', 0, 0, 0, 10134798, 0, 841328525, N'', null, null, N'', 0, 0, 0, 0, 0, 0, N'', null, 0, 0, 0, 0);
INSERT INTO core.ctaccount (division_id, account_ref, account_cd, lead_liab_name, lead_liab_pos, for_addr1, for_addr2, for_addr3, for_addr4, for_postcode, for_district, paymeth_code, paymeth_type, prev_paymeth, prev_paymeth_type, employee_ind, employee_no, swipe_issue_date, swipe_card_request, hb_sar, fast_track, equal_access_code, sched_code, person_status, transmission_date, lead_liab_title, lead_liab_forename, lead_liab_middlename, lead_liab_surname, lead_consent_ind, for_addr_last_updated, hb_archive_ind, party_ref, for_addr_verified, last_updated_int, prohibit_code, prohibit_end, prohibit_set, prohibit_user, prohibit_online_spd, for_addr_abroad, documerge_excl_ind, vulnerable_ind, prohibit_autorefund, suppress_spd_ver, suppress_user, suppress_date, prohibit_dd_over_web, prohibit_auto_move, prohibit_prov_arrg, vulnerable_cust) VALUES (1, 30548418, N'2', N'COOK,MR ROGER', 8, N'44 JUDGE STREET,', N'WATFORD,', N'HERTFORDSHIRE', N'', N'WD2 5AW', N'', N'CASHM', 1, N'     ', 0, 0, N'            ', null, 0, 0, 0, N'', N'', N'', null, N'Mr', N'ROGER', N'', N'COOK', 0, 0, 0, 10227409, 0, 841328525, N'', null, null, N'', 0, 0, 0, 0, 0, 0, N'', null, 0, 0, 0, 0);
