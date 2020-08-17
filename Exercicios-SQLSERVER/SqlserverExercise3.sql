select count(idProcesso) Qtd, DtEncerramento from tb_Processo 
GROUP BY DtEncerramento
HAVING COUNT(idProcesso) > 5;