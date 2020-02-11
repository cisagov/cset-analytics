import { NgModule } from '@angular/core';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTreeModule } from '@angular/material/tree';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatToolbarModule, MatProgressBarModule, MatAutocompleteModule, MatSlideToggleModule, MatSidenavModule, MatListModule } from '@angular/material';


@NgModule({
  imports: [
    MatButtonModule,
    MatIconModule,
    MatButtonToggleModule,
    MatRadioModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    DragDropModule,
    MatCardModule,
    MatExpansionModule,
    MatInputModule,
    MatSlideToggleModule,
    MatAutocompleteModule,
    MatTooltipModule,
    MatChipsModule,
    MatTreeModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatTabsModule,
    MatToolbarModule,
    MatMenuModule,
    MatSidenavModule
  ],
  exports: [
    MatButtonModule,
    MatButtonToggleModule,
    MatIconModule,
    MatRadioModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDialogModule,
    DragDropModule,
    MatCardModule,
    MatExpansionModule,
    MatInputModule,
    MatSlideToggleModule,
    MatAutocompleteModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatChipsModule,
    MatTreeModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatTabsModule,
    MatToolbarModule,
    MatMenuModule,
    MatSidenavModule,
    MatListModule
  ]
})
export class MaterialModule { }
