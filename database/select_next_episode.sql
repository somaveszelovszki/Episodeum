select e.* from episode e
join (select e._id, min(e.episode_number) from episode e
	join filmography_to_user ftu on ftu.filmography_id=e._id
	join (select s._id, min(s.season_number) from season s
					join filmography_to_user ftu on ftu.filmography_id=s._id
					where ftu.filmography_type_id=3
					and ftu.finished=0
					and ftu.user_id=1
					and s.series_id=19
					and s.season_number>0
	) s on e.season_id=s._id
	where ftu.filmography_type_id=2
	and ftu.finished=0
	and ftu.user_id=1
) e2 on e._id=e2._id;





select e.* from episode e
	join (select e._id, min(e.episode_number) from episode e
		join filmography_to_user ftu on ftu.filmography_id = e._id
		join (select s._id, min(s.season_number) from season s
			join filmography_to_user ftu on ftu.filmography_id = s._id
			where ftu.filmography_type_id = 3
			and ftu.finished = 0
			and ftu.user_id = 1
			and s.series_id = 20
			and s.season_number > 0
		) s on e.season_id = s._id
		where ftu.filmography_type_id = 2
		and ftu.finished = 0
		and ftu.user_id = 1
) e2 on e._id = e2._id;
