





select 1 as RowNo,'STD' as A,sum(Balance) as B from repRWMS where Mark=0
union
select 2 as RowNo,'NPA' as A,sum(Balance) as B from repRWMS where Mark=1
union 
select 3 as RowNo,'NF' as A,sum(Balance) as B from repRWMS where Mark=2
union
select 4 as RowNo,'UND' as A,sum(Balance) as B from repRWMS where Mark=3


select ascii('A')