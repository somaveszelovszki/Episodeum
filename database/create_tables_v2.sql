BEGIN TRANSACTION;
CREATE TABLE "user" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`username`	TEXT NOT NULL UNIQUE
);
CREATE TABLE "series_status" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`name`	TEXT NOT NULL UNIQUE
);
INSERT INTO `series_status` VALUES (1,'continuing');
INSERT INTO `series_status` VALUES (2,'ended');
CREATE TABLE "series" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`title`	TEXT,
	`tmdb_id`	INTEGER NOT NULL UNIQUE,
	`imdb_id`	TEXT,
	`overview`	TEXT,
	`vote_average`	REAL,
	`release_date`	TEXT,
	`poster_path`	TEXT,
	`number_of_seasons`	INTEGER,
	`number_of_episodes`	INTEGER,
	`status_id`	INTEGER NOT NULL,
	`episode_run_time`	INTEGER,
	FOREIGN KEY(`_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`status_id`) REFERENCES `series_status`(`_id`)
);
CREATE TABLE "season" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`title`	TEXT,
	`tmdb_id`	INTEGER NOT NULL UNIQUE,
	`overview`	TEXT,
	`release_date`	TEXT,
	`poster_path`	TEXT,
	`series_id`	INTEGER NOT NULL,
	`season_number`	INTEGER NOT NULL,
	FOREIGN KEY(`_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`series_id`) REFERENCES `series`(`_id`)
);
CREATE TABLE "rating" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`name`	TEXT NOT NULL UNIQUE
);
INSERT INTO `rating` VALUES (1,'liked');
INSERT INTO `rating` VALUES (2,'disliked');
CREATE TABLE "filmography_type" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`name`	TEXT NOT NULL UNIQUE
);
INSERT INTO `filmography_type` VALUES (1,'series');
INSERT INTO `filmography_type` VALUES (2,'episode');
INSERT INTO `filmography_type` VALUES (3,'season');
INSERT INTO `filmography_type` VALUES (4,'movie');
CREATE TABLE "filmography_to_user" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`filmography_id`	INTEGER NOT NULL,
	`filmography_type_id`	INTEGER NOT NULL,
	`user_id`	INTEGER NOT NULL,
	`review`	TEXT,
	`rating_id`	INTEGER,
	`finished`	INTEGER NOT NULL DEFAULT 0,
	`seconds_watched`	INTEGER NOT NULL DEFAULT 0,
	FOREIGN KEY(`filmography_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`user_id`) REFERENCES `user`(`_id`),
	FOREIGN KEY(`rating_id`) REFERENCES `rating`(`_id`)
);
CREATE TABLE "episode" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`title`	TEXT,
	`tmdb_id`	INTEGER NOT NULL UNIQUE,
	`imdb_id`	TEXT UNIQUE,
	`overview`	BLOB,
	`vote_average`	REAL,
	`release_date`	TEXT,
	`poster_path`	TEXT,
	`season_id`	INTEGER NOT NULL,
	`episode_number`	INTEGER NOT NULL,
	FOREIGN KEY(`_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`season_id`) REFERENCES `season`(`_id`)
);
COMMIT;
