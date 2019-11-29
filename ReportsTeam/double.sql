

--create proc TotAdv as
select 'Bill' as Bill,sum(Balance)as Balance from BillDetail where delsta is null
select 'CC' as CC,sum(Balance)as Balance from BillDetail where delsta is null
select 'DL' as DL,sum(Balance)as Balance from BillDetail where delsta is null


