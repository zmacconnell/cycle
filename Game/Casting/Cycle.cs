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
        private List<Actor> _segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a LightCycle.
        /// </summary>
        public Cycle(int colorChoice)
        {
            PrepareCycle(colorChoice);
        }

        /// <summary>
        /// Gets the bike's trail segments.
        /// </summary>
        /// <returns>The trail segments in a List.</returns>
        public List<Actor> GetTrail()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the lightbike's bike segment.
        /// </summary>
        /// <returns>The bike segment as an instance of Actor.</returns>
        public Actor GetBike()
        {
            return _segments[0];
        }

        /// <summary>
        /// Gets the lightbike's segments (including the head).
        /// </summary>
        /// <returns>A list of lightbike segments as instances of Actors.</returns>
        public List<Actor> GetCycle()
        {
            return _segments;
        }

        /// <summary>
        /// Grows the lightbike's trail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTrail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor trail = _segments.Last<Actor>();
                Point velocity = trail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = trail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.GREEN);
                _segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _segments)
            {
                segment.MoveNext();
            }

            for (int i = _segments.Count - 1; i > 0; i--)
            {
                Actor trailing = _segments[i];
                Actor previous = _segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the bike of the lightbike in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnBike(Point direction)
        {
            _segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the lightbike trail for moving.
        /// </summary>
        private void PrepareCycle(int colorChoice)
        {
            Random random = new Random();
            int x = random.Next(0,Constants.MAX_X);
            int y = random.Next(0,Constants.MAX_Y);
            // int x = Constants.MAX_X / 2;
            // int y = Constants.MAX_Y / 2;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = Constants.WHITE;
                if (colorChoice == 0) {
                    color = i == 0 ? Constants.YELLOW : Constants.GREEN;
                }
                else if (colorChoice == 1) {
                    color = i == 0 ? Constants.YELLOW : Constants.RED;
                }
                
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                _segments.Add(segment);
            }
        }
    }
}