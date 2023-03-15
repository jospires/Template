import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Project } from '../project.model';
import { ProjectsService } from '../projects.service';
import { TeamsService } from '../../teams/teams.service';
import { Team } from '../../teams/team.model';

@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.css']
})

export class ProjectEditComponent implements OnInit {

  teams!: Team[];

  project: Project = {
    id: 0,
    teamId: 0,
    name: '',
    description: '',
    startDate: new Date(),
    expectedEndDate: new Date(),
    endDate: new Date(),
    team:null
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private projectsService: ProjectsService,
    private teamsService: TeamsService
  ) { }

  ngOnInit() {
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams[0];
    });

    let _id: number = this.route.snapshot.params['id'];

    this.projectsService.getProject(_id)
      .subscribe(project => this.project = project);
  }

  saveProject(): void {
    if (this.project) {
      this.projectsService.updateProject(this.project)
        .subscribe(() => this.goBack());
    }
  }

  goBack(): void {
    this.router.navigate(['/projects']);
  }
}
