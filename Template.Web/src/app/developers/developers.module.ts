import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

import { DeveloperListComponent } from './developer-list/developer-list.component';
import { DeveloperCreateComponent } from './developer-create/developer-create.component';
import { DeveloperEditComponent } from './developer-edit/developer-edit.component';
import { SharedModule } from '../shared/shared.module';

const routes: Routes = [
  { path: '', component: DeveloperListComponent },
  { path: 'create', component: DeveloperCreateComponent },
  { path: 'edit/:id', component: DeveloperEditComponent },
];

@NgModule({
  declarations: [
    DeveloperListComponent,
    DeveloperCreateComponent,
    DeveloperEditComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    NgbModule,
    NgxPaginationModule,
    SharedModule
  ]
})
export class DevelopersModule { }
