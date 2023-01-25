import { Component } from '@angular/core';
import { FormBuilder  } from '@angular/forms';
import { Params } from '@angular/router';
import { PlayerSearchService } from '../player-search-service/player-search.service';
import { Player } from '../_interfaces/player';

@Component({
  selector: 'app-player-search',
  templateUrl: './player-search.component.html',
  styleUrls: ['./player-search.component.css']
})
export class PlayerSearchComponent {

  player: Player = {
    Classification: 0,
    Name: '',
    Tribe: '',
    Points: 0,
    Villages: 0,
    PointsPerVillage: 0
  };

  playerSearchForm = this.formBuilder.group({
      playerName: 'Who Am I?',
      world: 117
  });

  constructor(
    private formBuilder: FormBuilder,
    private playerSearchService: PlayerSearchService
  ) {}

  onSubmit(): void {
    const reqParams = this.getRequestParameters();
    
    this.playerSearchService
      .GetPlayerClassificationInfo(reqParams)
      .subscribe({
        next: (params: Params) => {
          this.player.Classification = params['classification'];
          this.player.Name = params['name'];
          this.player.Tribe = params['tribe'];
          this.player.Points = params['points'];
          this.player.Villages = params['villages'];
          this.player.PointsPerVillage = params['pointsPerVillage'];
        },
        error: (error) => {
          if (error.status === 404) {
            this.player.Name = "Player Not Found"
          }
          
          console.log("error occured in player-search.component.ts - method onSubmit.")
        }
      });
  }

  private getRequestParameters(): string {
    return '/' + this.playerSearchForm.value.playerName + '/' + this.playerSearchForm.value.world;
  }
}
