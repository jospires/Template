import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Team } from '../team.model';
import { TeamsService } from '../teams.service';

@Component({
  selector: 'app-team-create',
  templateUrl: './team-create.component.html',
  styleUrls: ['./team-create.component.css']
})

export class TeamCreateComponent implements OnInit {
  newTeam: Team = {
    id: 0,
    name: '',
    description: ''
    };

  constructor(
    private router: Router,
    private teamsService: TeamsService
  ) { }

  ngOnInit() { }

  createTeam(): void {
    this.teamsService.createTeam(this.newTeam)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.router.navigate(['/teams']);
  }
}
