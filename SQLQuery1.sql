
INSERT INTO [dbo].[ANAGRAFICA] ([IdAnagrafica], [Cognome], [Nome], [Indirizzo], [Città], [CAP], [Cod_Fisc]) VALUES
(1, 'Rossi', 'Mario', 'Via Roma 1', 'Palermo', '90100', 'RSSMRA80A01H501U'),
(2, 'Bianchi', 'Luigi', 'Via Milano 2', 'Milano', '20100', 'BNCGLI70B02F205N'),
(3, 'Verdi', 'Anna', 'Via Napoli 3', 'Napoli', '80100', 'VRDANN75D01F205N');


INSERT INTO [dbo].[TIPO_VIOLAZIONE] ([IdViolazione], [Descrizione]) VALUES
(1, 'Eccesso di velocità'),
(2, 'Sosta vietata'),
(3, 'Guida pericolosa');


INSERT INTO [dbo].[VERBALE] ([IdVerbale], [DataViolazione], [IndirizzoViolazione], [Nominativo_Agente], [DataTrascrizioneVerbale], [Importo], [DecurtamentoPunti], [IdAnagrafica], [IdViolazione]) VALUES
(1, '2024-06-01', 'Via Roma 1', 'Agente A', '2024-06-02', 150.00, 2, 1, 1),
(2, '2024-06-10', 'Via Milano 2', 'Agente B', '2024-06-11', 200.00, 3, 2, 2),
(3, '2024-06-15', 'Via Napoli 3', 'Agente C', '2024-06-16', 300.00, 4, 3, 3);
