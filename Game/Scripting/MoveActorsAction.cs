using System.Collections.Generic;
using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{
    // TODO: Implement the MoveActorsAction class here
    
    // 1) Add the class declaration. Use the following class comment. Make sure you
    //    inherit from the Action class.

    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
    public class MoveActorsAction : Action
    {
        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {
        }

        int _trail = 0;

       /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetAllActors();
            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
                _trail += 1;
                if (_trail % 30 == 0) {
                    cycle1.GrowTrail(1);
                    cycle2.GrowTrail(1);
                }
            }
        }
    }
    // 2) Create the class constructor. Use the following method comment.

    
    // 3) Override the Execute(Cast cast, Script script) method. Use the following 
    //    method comment. You custom implementation should do the following:
    //    a) get all the actors from the cast
    //    b) loop through all the actors
    //    c) call the MoveNext() method on each actor.
}