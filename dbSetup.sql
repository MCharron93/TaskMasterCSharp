-- CREATE TABLE profiles(
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )
-- CREATE TABLE lists (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     isPublished TINYINT NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )