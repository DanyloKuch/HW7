using System;

namespace DecoratorExample
{
    // Component
    abstract class ChristmasTree
    {
        public abstract void Display();
    }

    // Concrete Component
    class SimpleChristmasTree : ChristmasTree
    {
        public override void Display()
        {
            Console.WriteLine("A simple Christmas Tree");
        }
    }

    // Decorator
    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public TreeDecorator(ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override void Display()
        {
            tree.Display();
        }
    }

    // Concrete Decorator 1: Ornaments
    class OrnamentsDecorator : TreeDecorator
    {
        public OrnamentsDecorator(ChristmasTree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Decorated with ornaments");
        }
    }

    // Concrete Decorator 2: Garland
    class GarlandDecorator : TreeDecorator
    {
        public GarlandDecorator(ChristmasTree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            AddGarland();
        }

        private void AddGarland()
        {
            Console.WriteLine("The tree is glowing with garlands");
        }
    }

    // MainApp test application
    class MainApp
    {
        static void Main()
        {
            // Create a simple Christmas tree
            ChristmasTree tree = new SimpleChristmasTree();

            // Decorate it with ornaments
            tree = new OrnamentsDecorator(tree);

            // Decorate it with garlands
            tree = new GarlandDecorator(tree);

            // Display the decorated tree
            tree.Display();

            Console.ReadKey();
        }
    }
}
