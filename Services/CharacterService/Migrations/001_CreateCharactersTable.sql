CREATE TABLE Characters (
    UserId nvarchar(450) not null foreign key references AspNetUsers(Id) ON DELETE CASCADE,
    CharacterId int primary key identity,
    TotalHealthPoints int,
    HealthPoints int,
    Strength int,
    Defense int,
    Agility int,
    Job varchar(64),
    SkillPoints int,
    TotalSkillPoint int
)