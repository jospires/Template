import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TeamsModule } from './teams/teams.module';
import { ProjectsModule } from './projects/projects.module';
import { DevelopersModule } from './developers/developers.module';

const routes: Routes = [
  { path: "teams", loadChildren: () => TeamsModule },
  { path: "projects", loadChildren: () => ProjectsModule },
  { path: "developers", loadChildren: () => DevelopersModule },
  { path: '**', redirectTo: '/teams' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
