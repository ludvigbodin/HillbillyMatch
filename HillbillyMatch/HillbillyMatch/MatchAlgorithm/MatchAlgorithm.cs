using Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HillbillyMatch.MatchAlgorithm
{
    public class MatchAlgorithm
    {
        //Algorithm to get a matching percentage for two users.
        public static double GetMatchPercentage(ApplicationUser identity, ApplicationUser user)
        {
            var matchingQuestions = 0;

            if (identity.QuestionKindOfHillbilly == user.QuestionKindOfHillbilly) matchingQuestions++;
            if (identity.QuestionBoundaries == user.QuestionBoundaries) matchingQuestions++;
            if (identity.QuestionDrive == user.QuestionDrive) matchingQuestions++;
            if (identity.QuestionDrunkPeriods == user.QuestionDrunkPeriods) matchingQuestions++;
            if (identity.QuestionLive == user.QuestionLive) matchingQuestions++;
            if (identity.QuestionSpeed == user.QuestionSpeed) matchingQuestions++;
            if (identity.QuestionFun == user.QuestionFun) matchingQuestions++;
            if (identity.QuestionFood == user.QuestionFood) matchingQuestions++;
            if (identity.QuestionMaterial == user.QuestionMaterial) matchingQuestions++;

            double percentage = matchingQuestions / (double)9;

            // decrease score by 3% for each of:
            // QuestionKindOfHillbilly, QuestionBoundaries, QuestionDrunkPeriods, QuestionLive
            // since they are more important for a perfect match

            var numberOfImportantMismatches = 0;

            if (identity.QuestionKindOfHillbilly != user.QuestionKindOfHillbilly) numberOfImportantMismatches++;
            if (identity.QuestionBoundaries != user.QuestionBoundaries) numberOfImportantMismatches++;
            if (identity.QuestionDrunkPeriods != user.QuestionDrunkPeriods) numberOfImportantMismatches++;
            if (identity.QuestionLive != user.QuestionLive) numberOfImportantMismatches++;

            percentage = percentage * Math.Pow(0.97, numberOfImportantMismatches) * 100;

            // increase score by 2% statically for each match:
            // QuestionKindOfHillbilly, QuestionBoundaries, QuestionDrunkPeriods, QuestionLive
            // since they are more important for a perfect match

            if (identity.QuestionKindOfHillbilly == user.QuestionKindOfHillbilly) percentage += 2;
            if (identity.QuestionBoundaries == user.QuestionBoundaries) percentage += 2;
            if (identity.QuestionDrunkPeriods == user.QuestionDrunkPeriods) percentage += 2;
            if (identity.QuestionLive == user.QuestionLive) percentage += 2;

            if (percentage >= 100)
                return 100;
            else
                return percentage; 
        }
    }
}