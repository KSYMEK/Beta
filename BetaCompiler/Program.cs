﻿using System;
using System.Linq;
using BetaCompiler.CodeAnalysis;
using BetaCompiler.CodeAnalysis.Binding;
using BetaCompiler.CodeAnalysis.Syntax;

namespace BetaCompiler {
	internal static class Program {
		private static void Main() {
			var showTree = false;
			while (true) {
				Console.Write("> ");
				var line = Console.ReadLine();

				if (string.IsNullOrEmpty(line))
					return;

				if (line == "#showTree") {
					showTree = !showTree;
					Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees.");
					continue;
				}

				if (line == "#cls") {
					Console.Clear();
					continue;
				}

				var syntaxTree = SyntaxTree.Parse(line);
				var binder = new Binder();
				var boundExpression = binder.BindExpression(syntaxTree.Root);
				var diagnostics = syntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();

				if (showTree) {
					Console.ForegroundColor = ConsoleColor.DarkGray;
					PrettyPrint(syntaxTree.Root);
					Console.ResetColor();
				}

				if (!diagnostics.Any()) {
					var evaluator = new Evaluator(boundExpression);
					var result = evaluator.Evaluate();
					Console.WriteLine(result);
				}
				else {
					Console.ForegroundColor = ConsoleColor.DarkRed;
					foreach (var diagnostic in diagnostics) Console.WriteLine(diagnostic);
					Console.ResetColor();
				}
			}
		}

		private static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true) {
			var marker = isLast ? "└──" : "├──";
			Console.Write(indent);
			Console.Write(marker);
			Console.Write(node.Kind);

			if (node is SyntaxToken t && t.Value != null) {
				Console.Write(" ");
				Console.Write(t.Value);
			}

			Console.WriteLine();

			indent += isLast ? "    " : "│   ";

			var lastChild = node.GetChildren().LastOrDefault();
			foreach (var child in node.GetChildren())
				PrettyPrint(child, indent, child == lastChild);
		}
	}
}