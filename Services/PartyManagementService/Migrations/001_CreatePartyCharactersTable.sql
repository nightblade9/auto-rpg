CREATE TABLE PartyCharacters (
    UserId nvarchar(450) not null foreign key references AspNetUsers(Id) ON DELETE CASCADE,
    CharacterId int foreign key references Characters(CharacterId),
    primary key (UserId, CharacterId)
)