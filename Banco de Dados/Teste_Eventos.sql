/*SELECT agendamento.data_emissao AS `Data Emissão`,
	agendamento.hora_evento AS `Horário Inicio`,
	agendamento.data_evento AS `Data Evento`,
	agendamento.local_evento AS `Local`,
 	cliente.nome AS `Cliente`,
 	agendamento.tema AS `Tema`
	
    FROM agendamento
    
    INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente

WHERE agendamento.id_agendamento = 1;

*/

SELECT itens_agendamento.quantidade AS `Quantidade`,
	produto.descricao AS `Descrição`,
	produto.valor AS `R$ Unitário`,
	itens_agendamento.subtotal AS `Valor`
	
    FROM itens_agendamento
    
    INNER JOIN produto ON itens_agendamento.id_produto = produto.id_produto

WHERE itens_agendamento.id_agendamento = 1;


/*
SELECT agendamento.data_emissao AS `Data Emissão`,
	agendamento.hora_evento AS `Horário Inicio`,
	agendamento.data_evento AS `Data Evento`,
	agendamento.local_evento AS `Local`,
 	cliente.nome AS `Cliente`,
 	agendamento.tema AS `Tema`,
	produto.descricao AS `Descrição`,
    itens_agendamento.quantidade AS `Quantidade`,
	produto.valor AS `R$ Unitário`,
	itens_agendamento.subtotal AS `Valor`,
    agendamento.total AS `Total`
    
    FROM agendamento
    
    INNER JOIN cliente ON agendamento.id_cliente = cliente.id_cliente
    INNER JOIN itens_agendamento ON agendamento.id_agendamento = agendamento.id_agendamento
    INNER JOIN produto ON produto.id_produto = itens_agendamento.id_produto

WHERE agendamento.id_agendamento = 1;

*/