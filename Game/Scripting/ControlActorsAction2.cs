using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction2 : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction2(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (_keyboardService.IsKeyDown("j"))
            {
                _direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("l"))
            {
                _direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("i"))
            {
                _direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("k"))
            {
                _direction = new Point(0, Constants.CELL_SIZE);
            }

            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            cycle.TurnCycle(_direction);

        }
    }
}