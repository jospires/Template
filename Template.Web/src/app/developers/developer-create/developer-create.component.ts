import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Developer } from '../developer.model';
import { DevelopersService } from '../developers.service';
import { TeamsService } from '../../teams/teams.service';
import { Team } from '../../teams/team.model';

@Component({
  selector: 'app-developer-create',
  templateUrl: './developer-create.component.html',
  styleUrls: ['./developer-create.component.css']
})

export class DeveloperCreateComponent implements OnInit {

  teams!: Team[];

  newDeveloper: Developer = {
    id: 0,
    teamId: 0,
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date(),
    team: null
  };

  constructor(
    private router: Router,
    private developersService: DevelopersService,
    private teamsService: TeamsService
  ) { }

  ngOnInit() {
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams[0];
    });
  }

  createDeveloper(): void {
    this.developersService.createDeveloper(this.newDeveloper)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.router.navigate(['/developers']);
  }
}
