use demoDB;

select * from Activity;

select 
round(cast(count(a2.player_id) as float)/count(a1.player_id), 2) as fraction
from (select player_id, min(event_date) as event_date from activity group by player_id) a1
left join (select distinct player_id, event_date from activity) a2
on a1.player_id = a2.player_id
and dateadd(day, 1, a1.event_date) = a2.event_date;