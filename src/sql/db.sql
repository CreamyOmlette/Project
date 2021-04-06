use Project;

CREATE TABLE Users
(
    [UserId] BIGINT PRIMARY KEY IDENTITY (1,1),
    [Username] VARCHAR(20) NOT NULL ,
    [Password] VARCHAR(20) NOT NULL ,
    [Height] TINYINT,
    [Weight] TINYINT,
    [DoB] DATE
);

CREATE TABLE Meals
(
    [MealId] BIGINT PRIMARY KEY IDENTITY (1,1),
    [Name] VARCHAR(100) NOT NULL,
    [Calories] INT NOT NULL ,
    [Carbohydrates] INT,
    [Fats] INT,
    [Proteins] INT,
    [Description] VARCHAR(500)
);

CREATE TABLE Exercises
(
    [ExerciseId] BIGINT PRIMARY KEY IDENTITY (1,1),
    [Name] VARCHAR(100) NOT NULL ,
    [Reps] TINYINT ,
    [Sets] TINYINT ,
    [Intensity] TINYINT NOT NULL ,
    [Time] TINYINT
);

CREATE TABLE Routines
(
    [RoutineId] BIGINT PRIMARY KEY IDENTITY (1,1),
    [Name] VARCHAR(100) NOT NULL ,
    [Difficulty] TINYINT NOT NULL ,
    [Description] VARCHAR(500)
);

CREATE TABLE RoutineExercise
(
    [Routine_fk] BIGINT FOREIGN KEY REFERENCES Routines(RoutineId),
    [Exercise_fk] BIGINT FOREIGN KEY REFERENCES Exercises(ExerciseId),
    [Status] BINARY DEFAULT 0
);

CREATE TABLE Day
(
    [UserId] BIGINT FOREIGN KEY REFERENCES Users(UserId),
    [Date] DATE DEFAULT GETDATE(),
    [Notes] VARCHAR(500),
    PRIMARY KEY ([UserId], [Date])
);

CREATE TABLE DayRoutine
(
    [RoutineId] BIGINT FOREIGN KEY REFERENCES Routines(RoutineId),
    [UserId] BIGINT NOT NULL ,
    [Date] DATE NOT NULL ,
    FOREIGN KEY ([UserId],[Date]) REFERENCES Day([UserId],[Date]),
    [Status] BINARY DEFAULT 0
);
CREATE TABLE DayMeal
(
    [MealId] BIGINT FOREIGN KEY REFERENCES Meals([MealId]),
    [UserId] BIGINT NOT NULL ,
    [Date] DATE NOT NULL ,
    FOREIGN KEY ([UserId],[Date]) REFERENCES Day([UserId],[Date]),
    [Status] BINARY DEFAULT 0
);