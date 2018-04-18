use RICHIESTE
go

create procedure AddRequest
	@id int,
	@quantita int,
	@datadioggi date
as
	declare @idRichiesta int;
	INSERT INTO RichiesteSet(data) VALUES(@datadioggi);
	set @idRichiesta = (SELECT IDENT_CURRENT('RichiesteSet'));
	INSERT INTO RichiesteProdotti(Richieste_Id,Prodotti_Id,quantita) VALUES(@idRichiesta,@id,@quantita);
go