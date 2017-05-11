BEGIN TRANSACTION;
CREATE TABLE `user` (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`username`	TEXT NOT NULL
);
CREATE TABLE "series_status" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`name`	TEXT NOT NULL UNIQUE
);
CREATE TABLE "series" (
	`_id`	INTEGER,
	`number_of_seasons`	INTEGER,
	`number_of_episodes`	INTEGER,
	`status_id`	INTEGER NOT NULL,
	`episode_run_time`	INTEGER,
	PRIMARY KEY(`_id`),
	FOREIGN KEY(`_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`status_id`) REFERENCES series_status(`_id`)
);
CREATE TABLE `season` (
	`_id`	INTEGER,
	`season_number`	INTEGER NOT NULL,
	`series_id`	INTEGER NOT NULL,
	PRIMARY KEY(`_id`),
	FOREIGN KEY(`_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`series_id`) REFERENCES `series`(`_id`)
);
CREATE TABLE "rating" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`name`	TEXT NOT NULL UNIQUE
);
CREATE TABLE "filmography_type" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`name`	TEXT NOT NULL UNIQUE
);
CREATE TABLE `filmography_to_user` (
	`_id`	INTEGER,
	`filmography_id`	INTEGER NOT NULL,
	`user_id`	INTEGER NOT NULL,
	`review`	TEXT,
	`rating_id`	INTEGER,
	`finished`	INTEGER NOT NULL DEFAULT 0,
	`seconds_watched`	INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY(`_id`),
	FOREIGN KEY(`filmography_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`user_id`) REFERENCES `user`(`_id`),
	FOREIGN KEY(`rating_id`) REFERENCES `rating`(`_id`)
);
CREATE TABLE "filmography" (
	`_id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`imdb_id`	TEXT UNIQUE,
	`tmdb_id`	INTEGER NOT NULL UNIQUE,
	`overview`	TEXT,
	`vote_average`	REAL,
	`title`	TEXT,
	`poster_path`	TEXT,
	`release_date`	TEXT,
	`type_id`	INTEGER NOT NULL,
	FOREIGN KEY(`type_id`) REFERENCES filmography_type(`_id`)
);
CREATE TABLE `episode` (
	`_id`	INTEGER,
	`season_id`	INTEGER NOT NULL,
	`episode_number`	INTEGER NOT NULL,
	PRIMARY KEY(`_id`),
	FOREIGN KEY(`_id`) REFERENCES `filmography`(`_id`),
	FOREIGN KEY(`season_id`) REFERENCES `season`(`_id`)
);
COMMIT;
