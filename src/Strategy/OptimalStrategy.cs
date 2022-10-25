﻿using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajesty.Strategy;

public class OptimalStrategy : IStrategy
{
    /// <summary>
    /// Stores all visited contenders
    /// </summary>
    private List<Contender> _visitedContenderList;
    
    private readonly IFriend _friend;
    private readonly IHall _hall;
    
    public OptimalStrategy(IFriend friend, IHall hall)
    {
        _friend = friend;
        _hall = hall;
        
        _visitedContenderList = new List<Contender>();
    }

    /// <summary>
    /// Implementation of the cutoff rule. The Princess do not accept any of the
    /// first {cutoff} contenders and then selects the first one that is better
    /// than all the previous ones.
    /// </summary>
    /// <returns> Returns the chosen contender. </returns>
    public Contender? ChooseBestContender()
    {
        var visited = 0;
        var cutoff = (int) Math.Round(Constants.ContenderCount / Math.E); // will be equal to 37

        while (_hall.GetNextContender() is { } contender)
        {
            visited += 1;
            _friend.AddVisitedContender(contender);
            _visitedContenderList.Add(contender);
            
            // Important: current contender must be already visited!
            if (visited >= cutoff
                && _friend.IsBetterThanVisited(contender)) 
            {
                return contender;
            }
        }
        return null;
    }

    /// <summary>
    /// Allows to view the list of all visited contenders
    /// </summary>
    /// <returns>
    /// Returns the list of visited contenders
    /// </returns>
    public List<Contender> ViewVisitedContenders()
    {
        return _visitedContenderList;
    }
}