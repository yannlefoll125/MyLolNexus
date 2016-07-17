﻿using MyLolNexus.Data;
using MyLolNexus.RestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus.Model {
    class ModelHelper {

        public static CurrentGameModel GetCurrentGameModel(ApiResourceBuilder.ServerRegion serverRegion, string summonerName) {

            Console.WriteLine("Requesting CurrentGameModel");

            CurrentGame currentGame = ApiHelper.RequestCurrentGame(serverRegion, summonerName);

            Console.WriteLine("CurrentGame has been fetched via the API");

            CurrentGameModel currentGameModel = new CurrentGameModel();

            foreach(Participant p in currentGame.participants) {
                ParticipantModel pm = new ParticipantModel();
                pm.SummonerName = p.summonerName;

                if(p.teamId == Constants.Team.Team1) {
                    currentGameModel.Team1.Add(pm);
                } else {
                    currentGameModel.Team2.Add(pm);
                }
                
            }

            return currentGameModel;
        }

    }
}