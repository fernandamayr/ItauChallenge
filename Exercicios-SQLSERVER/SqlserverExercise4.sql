Select REPLICATE('0', 12 - LEN(nroProcesso)) + RTrim(cast(nroProcesso as varchar))
from  tb_Processo;