using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IBird
    {
        Egg Lay();
    }

    public class Egg
    {
        private readonly Func<IBird> _createBird;
        private bool _isHatched;

        public Egg(Func<IBird> createBird)
        {
            _createBird = createBird;
        }

        public IBird Hatch()
        {
            if (_isHatched)
            {
                throw new InvalidOperationException("Egg already hatched.");
            }
            _isHatched = true;
            return _createBird();
        }
    }

    public class Chicken : IBird
    {
        public Chicken()
        {
        }

        public Egg Lay()
        {
            var egg = new Egg(() => new Chicken());
            return egg;
        }
    }

    class CbaTest
    {
    }
}
