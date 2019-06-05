using Microsoft.SolverFoundation.Services;
using System;
using System.Linq;

namespace OptimalRangeSelection
{
    class Solver
    {

        private readonly SolverContext context;
        private readonly Model model;
        private Solution solution;
        private readonly Decision x;
        private readonly Decision y;
        private readonly Decision z;
        private readonly string product1;
        private readonly string product2;

        public Solver(string p1, string p2) {

            product1 = p1;
            product2 = p2;

            // Create solver context and model
            context = SolverContext.GetContext();
            context.ClearModel();
            model = context.CreateModel();

            // Create decision for objective function
            x = new Decision(Domain.RealNonnegative, product1);
            y = new Decision(Domain.RealNonnegative, product2);

            model.AddDecisions(x, y);
        }

        public void AddProductionContraints(int argx1, int argy1, int argx2, int argy2, int argx3, int argy3, int wyn1, int wyn2, int wyn3) {
            model.AddConstraints("production",
              argx1 * x + argy1 * y <= wyn1,
              argx2 * x + argy2 * y <= wyn2);
        }

        public void AddNonNegativeVariables(int wyn1, int wyn2) {
            model.AddConstraints("nonnegative",
              x >= wyn1,
              y >= wyn2);
        }

        public void AddGoal(int argx, int argy, string goalName = "cost") {
            model.AddGoal(goalName, GoalKind.Maximize,
              argx * x + argy * y);
        }


        public void Solve() {
            solution = context.Solve(new SimplexDirective());
        }

        public void PrintResults(System.Windows.Forms.TextBox textBox1)
        {
            Report report = solution.GetReport();
            textBox1.Text = $"result: {solution.Goals.First().ToDouble()}";
            textBox1.Text += $"{Environment.NewLine}{product1}: {x.ToDouble()}{Environment.NewLine}{product2}: {y.ToDouble()}";
            textBox1.Text += $"{Environment.NewLine}{report}";
        }
    }
}