select count(*) as Qtd_registros, 
p.idStatus, 
s.dsStatus
from 
tb_Processo p,
tb_Status s
where p.idStatus = s.idStatus
group by p.idStatus, 
s.dsStatus;