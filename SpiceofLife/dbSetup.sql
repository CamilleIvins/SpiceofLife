CREATE TABLE
    IF NOT EXISTS accounts (
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- TABLES

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        category VARCHAR(100) NOT NULL,
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(5000) NOT NULL,
        img VARCHAR(500) NOT NULL,
        archived TINYINT DEFAULT 0,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes;

DROP TABLE account;

DROP TABLE ingredients;

-- ingredients table is throwing errors...

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(255),
        quantity VARCHAR(100) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        recipeId int NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

-- INSERTS

-- INSERTS for recipes

-- INSERT INTO

--     recipes(

--         category,

--         title,

--         coverImg,

--         creatorId

--     )

-- VALUES (

--         'Soup',

--         'Butternut Squash with Cauliflower',

--         'https://i2.wp.com/fortheloveofgourmet.com/wp-content/uploads/2020/02/IMG_1673-e1580680990890.jpg?resize=768%2C1152&ssl=1',

--         '64ee867f129b583aaa5c5042'

--     );

-- INSERT INTO

--     recipes(

--         category,

--         title,

--         coverImg,

--         creatorId

--     )

-- VALUES (

--         'Soup',

--         'Beef Stew',

--         'https://images.unsplash.com/photo-1608500219063-e5164085cd6f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YmVlZiUyMHN0ZXd8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=1000&q=60',

--         '64ee867f129b583aaa5c5042'

--     );

-- INSERT INTO

--     recipes(

--         category,

--         title,

--         coverImg,

--         creatorId

--     )

-- VALUES (

--         'Salad',

--         'Greek Salad',

--         'https://images.unsplash.com/photo-1626200926749-cccc3d2caf12?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=871&q=80',

--         '64ee867f129b583aaa5c5042'

--     );

-- INSERT INTO

--     recipes(

--         category,

--         title,

--         coverImg,

--         creatorId

--     )

-- VALUES (

--         'Smoothie',

--         'Açaí Bowl',

--         'https://images.unsplash.com/photo-1590301157284-ab2f8707bdc1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80',

--         '64ee867f129b583aaa5c5042'

--     );