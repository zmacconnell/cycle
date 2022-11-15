using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A cycle that races on a ribbon of light.</para>
    /// <para>The responsibility of Bike is to move itself and leave a trail.</para>
    /// </summary>
    public class Cycle : Actor
    {
        private List<Actor> _trail = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a LightCycle.
        /// </summary>
        public Cycle()
        {
            PrepareCycle();
        }

        /// <summary>
        /// Gets the bike's trail segments.
        /// </summary>
        /// <returns>The trail segments in a List.</returns>
        public List<Actor> GetTrail()
        {
            return new List<Actor>(_trail.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the lightbike's bike segment.
        /// </summary>
        /// <returns>The bike segment as an instance of Actor.</returns>
        public Actor GetCycle()
        {
            return _trail[0];
        }

        /// <summary>
        /// Gets the lightbike's segments (including the head).
        /// </summary>
        /// <returns>A list of lightbike segments as instances of Actors.</returns>
        public List<Actor> GetTrails()
        {
            return _trail;
        }

        /// <summary>
        /// Grows the lightbike's trail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTrail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor trail = _trail.Last<Actor>();
                Point velocity = trail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = trail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.GREEN);
                _trail.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _trail)
            {
                segment.MoveNext();
            }

            for (int i = _trail.Count - 1; i > 0; i--)
            {
                Actor trailing = _trail[i];
                Actor previous = _trail[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the bike of the lightbike in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnCycle(Point direction)
        {
            _trail[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the lightbike trail for moving.
        /// </summary>
        private void PrepareCycle()
        {
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? Constants.YELLOW : Constants.GREEN;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                _trail.Add(segment);
            }
        }
    }
}