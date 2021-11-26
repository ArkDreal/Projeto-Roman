INSERT INTO [dbo].[tipoUsuario] (nomeTipo)
VALUES ('Administrador'), ('Professor')

INSERT INTO [dbo].[usuario] (idTipoUsuario, email, senha)
VALUES (2, 'saulo@gmail.com', 'saulo123'), (2, 'lucas@gmail.com', 'lucas123')

INSERT INTO [dbo].[professor] (idUsuario, nome, sobrenome, cpf)
VALUES (1, 'Saulo', 'Santos', '111111111'), (2, 'Lucas', 'Aragão', '222222222')
