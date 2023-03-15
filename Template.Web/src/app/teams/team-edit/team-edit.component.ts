import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Team } from '../team.model';
import { TeamsService } from '../teams.service';

@Component({
  selector: 'app-team-edit',
  templateUrl: './team-edit.component.html',
  styleUrls: ['./team-edit.component.css']
})
export class TeamEditComponent implements OnInit {
  team: Team = {
    id: 0,
    name: '',
    description: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private teamsService: TeamsService
  ) { }

  ngOnInit() {
    let _id: number = this.route.snapshot.params['id'];

    this.teamsService.getTeam(_id)
      .subscribe(team => this.team = team);
  }

  saveTeam(): void {
    if (this.team) {
      this.teamsService.updateTeam(this.team)
        .subscribe(() => this.goBack());
    }
  }

  goBack(): void {
    this.router.navigate(['/teams']);
  }
}
