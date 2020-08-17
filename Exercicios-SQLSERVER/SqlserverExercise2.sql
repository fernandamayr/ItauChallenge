select max(a.dtAndamento), 
a.idProcesso 
from tb_Andamento a
where a.idProcesso in (
select idProcesso from tb_Processo 
where YEAR(DtEncerramento) = 2013)
group by a.idProcesso;