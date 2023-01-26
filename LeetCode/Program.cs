using LeetCode;
using System.Text;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, LeetCode!");

KClosestSol kClosestSol = new KClosestSol();
var input = new int[][] {
                new int[] { 1, 3 },
                new int[] { -2, 2 }
            };

kClosestSol.KClosest(input, 1);

input = new int[][] {
                new int[] { 3, 3 },
                new int[] { 5, -1 },
                new int[] { -2, 4 }
            };

kClosestSol.KClosest(input, 2);

countFamilyLoginsSol countFamilyLoginsSol = new countFamilyLoginsSol();
List<string> logins = new List<string>();
//logins.AddRange(new[] { "bag", "sfe", "cbh", "cbh", "red" });
logins.AddRange(new[] { "corn", "horn", "dpso", "eqtp", "corn" });

countFamilyLoginsSol.countFamilyLogins(logins);

findTotalImbalanceSol findTotalImbalanceSol = new findTotalImbalanceSol();
List<int> rank = new List<int>();
rank.AddRange(new int[] { 4, 1, 3, 2 });
findTotalImbalanceSol.findTotalImbalance(rank);

MinMeetingRoomsSol minMeetingRoomsSol = new MinMeetingRoomsSol();

input = new int[][] {
                new int[] { 3, 30 },
                new int[] { 15, 20 },
                new int[] { 5, 10 }
            };
minMeetingRoomsSol.MinMeetingRooms(input);

input = new int[][] {
                new int[] { 7, 10 },
                new int[] { 2, 4 }
            };
minMeetingRoomsSol.MinMeetingRooms(input);

GetMaxLenSol getMax = new GetMaxLenSol();
getMax.GetMaxLen(new int[] { -1 });
getMax.GetMaxLen(new int[] { -16, 0, -5, 2, 2, -13, 11, 8 });
//getMax.GetMaxLen(new int[] { 1, 2, 3, 5, -6, 4, 0, 10 });
//getMax.GetMaxLen(new int[] { 0, 1, -2, -3, -4 });
//getMax.GetMaxLen(new int[] { -1, -2, -3,0, 1 });

input = new int[][] {
                new int[] { 1, 0 },
                new int[] { 1, 1 }
            };
CountServersSol countServersSol = new CountServersSol();
countServersSol.CountServers(input);

input = new int[][] {
                new int[] { 1,0,0,1,0 },
                new int[] { 0,0,0,0,0 },
                new int[] { 0,0,0,1,0 }
            };
countServersSol.CountServers(input);

IsPowerOfThreeSol isPowerOfThreeSol = new IsPowerOfThreeSol();
isPowerOfThreeSol.IsPowerOfThree(12);

HouseRobber houseRobber = new HouseRobber();
houseRobber.Rob(new int[] { 2, 1,1,2 });
houseRobber.Rob(new int[] { 1, 2, 3, 1 });
houseRobber.Rob(new int[] { 2, 7, 9, 3, 1 });
houseRobber.Rob(new int[] { 9, 1, 1, 1, 9 });

LongestStrChainSol longestStr = new LongestStrChainSol();
longestStr.LongestStrChain(new string[] { "a", "ab", "ac", "bd", "abc", "abd", "abdd" });
longestStr.LongestStrChain(new string[] { "bdca", "bda", "ca", "dca", "a" });
longestStr.LongestStrChain(new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" });

RacecarSol racecarSol = new RacecarSol();
racecarSol.Racecar(4);
racecarSol.Racecar(9);
racecarSol.Racecar(6);
racecarSol.Racecar(3);

TreeNode tree = null;
GetDirectionsSol directionsSol = new GetDirectionsSol();

tree = new TreeNode(1, null, new TreeNode(10, new TreeNode(12, new TreeNode(4), new TreeNode(6)), new TreeNode(13, null, new TreeNode(15))));
directionsSol.GetDirections(tree, 6, 15);

tree = new TreeNode(3, new TreeNode(1), new TreeNode(2));
directionsSol.GetDirections(tree, 2, 1);

tree = new TreeNode(2, new TreeNode(1));
directionsSol.GetDirections(tree, 2, 1);

FindLeavesofBinaryTree findLeaves = new FindLeavesofBinaryTree();
tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
findLeaves.FindLeaves(tree);

FindPivotIndex pivotIndex = new FindPivotIndex();
pivotIndex.PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 });

MaximumEvenSplitSol MaximumEvenSplitSol = new MaximumEvenSplitSol();
MaximumEvenSplitSol.MaximumEvenSplit(2);
MaximumEvenSplitSol.MaximumEvenSplit(12);
MaximumEvenSplitSol.MaximumEvenSplit(10);

MyCalendarI MyCalendarI = new MyCalendarI();
MyCalendarI.Book(10, 15);
MyCalendarI.Book(8, 9);
MyCalendarI.Book(20, 30);
MyCalendarI.Book(15, 20);
MyCalendarI.Book(40, 50);

FindAllRecipesSol FindAllRecipesSol = new FindAllRecipesSol();
List<IList<string>> reps = new List<IList<string>>();
reps.Add(new List<string>(new string[] { "d" }));
reps.Add(new List<string>(new string[] { "hveml", "f", "cpivl" }));
reps.Add(new List<string>(new string[] { "cpivl", "zpmcz", "h", "e", "fzjnm", "ju" }));
reps.Add(new List<string>(new string[] { "cpivl", "hveml", "zpmcz", "ju", "h" }));
reps.Add(new List<string>(new string[] { "h", "fzjnm", "e", "q", "x" }));
reps.Add(new List<string>(new string[] { "d", "hveml", "cpivl", "q", "zpmcz", "ju", "e", "x" }));
reps.Add(new List<string>(new string[] { "f", "hveml", "cpivl" }));
FindAllRecipesSol.FindAllRecipes2(new string[] { "ju", "fzjnm", "x", "e", "zpmcz", "h", "q" }, reps, new string[] { "f", "hveml", "cpivl", "d" });


DetectSquares detectSquares = new DetectSquares();
detectSquares.Add(new int[] { 3, 10 });
detectSquares.Add(new int[] { 11, 2 });
detectSquares.Add(new int[] { 3, 2 });
detectSquares.Count(new int[] { 11, 10 });
detectSquares.Count(new int[] { 14, 8 });
detectSquares.Add(new int[] { 11, 2 });
detectSquares.Count(new int[] { 11, 10 });

EarliestMoment earliestMoment = new EarliestMoment();
input = new int[][] {
                new int[] { 20190101,0,1 },
                new int[] { 20190104,3,4 },
                new int[] { 20190107, 2, 3 },
                new int[] { 20190211,1,5 },
                new int[] { 20190224,2,4},
                new int[] { 20190301, 0, 3 },
                new int[] { 20190312,1,2 },
                new int[] { 20190322, 4, 5 }
            };
// earliestMoment.EarliestAcq(input, 6);

input = new int[][] {
                new int[] {3,2,4 },
                new int[] {6,5,0 },
                new int[] { 10,4,1 },
                new int[] { 7,1,0 },
                new int[] {0,1,6 },
                new int[] { 1, 5, 4 },
                new int[] { 8,5,3 },
                new int[] {2,5,1 },
                new int[] { 12,2,6 },
                new int[] { 11,6,5 },
                new int[] {4,6,3 },
                new int[] { 5,4,0 },

            };
earliestMoment.EarliestAcq(input, 7);

ShortestWaySol ShortestWaySol = new ShortestWaySol();
ShortestWaySol.ShortestWay("adbsc", "addddddddddddsbc");
ShortestWaySol.ShortestWay("xyz", "xzyxz");
ShortestWaySol.ShortestWay("abc", "abcbc");
ShortestWaySol.ShortestWay("abc", "abdbc");
ShortestWaySol.ShortestWay("adbsc", "addddddddddddsbc");
ShortestWaySol.ShortestWay("aaaaa", "aaaaaaaaaaaaa");

MaxPointsSol MaxPointsSol = new MaxPointsSol();

input = new int[][] {
                new int[] { 5, 2, 1, 2 },
                new int[] { 2, 1, 5, 2 },
                new int[] { 5, 5, 5, 0 }
            };
MaxPointsSol.MaxPoints(input);

input = new int[][] {
                new int[] {1, 2, 3 },
                new int[] {1, 5, 1 },
                new int[] { 3, 1, 1 }
            };
MaxPointsSol.MaxPoints(input);

input = new int[][] {
                new int[] { 0,0,4,1,4 },
                new int[] { 2,1,2,0,1 },
                new int[] { 2,2,1,3,4 },
                new int[] { 5, 2, 4, 5, 4 },
                new int[] { 0, 5, 4, 2, 5 }
            };
MaxPointsSol.MaxPoints(input);

input = new int[][] {
                new int[] {1 ,   2 ,  4,   4  , 3},
                new int[] {1  ,  4 ,  5 ,  5 ,  1 },
                new int[] { 5  , 2 ,  3  , 5 ,  5 },
                new int[] { 2 ,  3 ,  4 ,  3 ,  0 }
            };
MaxPointsSol.MaxPoints(input);


input = new int[][] {
                new int[] {1, 5 },
                new int[] {2, 3 },
                new int[] {4, 2 }
            };
MaxPointsSol.MaxPoints(input);

GetDirectionsSol2 directionsSol2 = new GetDirectionsSol2();
tree = new TreeNode(5, new TreeNode(1, new TreeNode(3)), new TreeNode(2, new TreeNode(6), new TreeNode(4)));
directionsSol2.GetDirections(tree, 3, 6);

FindMinDifferenceSol FindMinDifferenceSol = new FindMinDifferenceSol();
FindMinDifferenceSol.FindMinDifference(new List<string>(new string[] { "23:59", "00:00", "00:10" }));
FindMinDifferenceSol.FindMinDifference(new List<string>(new string[] { "23:59", "00:00", "00:10", "00:00" }));

WordCountSol wordCountSol = new WordCountSol();
wordCountSol.WordCount(new string[] { "ant", "act", "tack" }, new string[] { "tack", "act", "acti" });
wordCountSol.WordCount(new string[] { "ab", "a" }, new string[] { "abc", "abcd" });

SparseVector v1 = new SparseVector(new int[] { 1, 0, 0, 2, 3 });
SparseVector v2 = new SparseVector(new int[] { 0, 3, 0, 4, 0 });
int ans = v1.DotProduct(v2);

VerticalOrderSol VerticalOrderSol = new VerticalOrderSol();
VerticalOrderSol.VerticalOrder(new TreeNode(3, new TreeNode(9, new TreeNode(4), new TreeNode(0, null, new TreeNode(2))), new TreeNode(8, new TreeNode(1, new TreeNode(5)), new TreeNode(7))));
VerticalOrderSol.VerticalOrder(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
VerticalOrderSol.VerticalOrder(new TreeNode(3, new TreeNode(9, new TreeNode(4), new TreeNode(0)), new TreeNode(8, new TreeNode(1), new TreeNode(7))));

ValidWordAbbreviationSol ValidWordAbbreviationSol = new ValidWordAbbreviationSol(); 
ValidWordAbbreviationSol.ValidWordAbbreviation("internationalization", "i5a11o1");
ValidWordAbbreviationSol.ValidWordAbbreviation("internationalization", "i12iz4n");
ValidWordAbbreviationSol.ValidWordAbbreviation("apple", "a2e");

SimplifyPathSol simplifyPath = new SimplifyPathSol();
simplifyPath.SimplifyPath("/home//foo/../bbb/");
simplifyPath.SimplifyPath("/a/./b/../../c/");

BasicCalculatorII basicCalculator = new BasicCalculatorII();
basicCalculator.Calculate(" 1-1+1 ");
basicCalculator.Calculate(" 3*5 + 2*4 - 1 ");
basicCalculator.Calculate(" 2-5*4 ");

GroupStringsSol groupStringsSol = new GroupStringsSol();
groupStringsSol.GroupStrings(new string[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" });

Node node1 = new Node(3);
Node node2 = new Node(3);
Node node3 = new Node(5);
node1.next = node2;
node2.next = node3;
node3.next = node1;
SortedCircularLinkedList SortedCircularLinkedList = new SortedCircularLinkedList();
SortedCircularLinkedList.Insert(node1, 4);

Node node4 = new Node(1);
SortedCircularLinkedList.Insert(node4, 1);

CustomSortStringSol customSortStringSol = new CustomSortStringSol();
customSortStringSol.CustomSortString("cba", "abcd");

ShortestPathBinaryMatrixSol shortestPath = new ShortestPathBinaryMatrixSol();
input = new int[][] {
                new int[] {0, 0, 0},
                new int[] {1, 1, 0},
                new int[] {1, 1, 1}
            };
shortestPath.ShortestPathBinaryMatrix(input);
input = new int[][] {
                new int[] {0, 0, 0, 1},
                new int[] {0, 0, 1, 0},
                new int[] {0, 1, 0, 0},
                new int[] {1, 0, 0, 0}
            };

shortestPath.ShortestPathBinaryMatrix(input);

SubsetsWithDupSol subsets = new SubsetsWithDupSol();
subsets.SubsetsWithDup(new int[] { 1, 2, 2 });

AccountsMergeSol accountsMergeSol = new AccountsMergeSol();
List<IList<string>> accounts= new List<IList<string>>();
accounts.Add(new List<string>(new string[] { "John", "johnsmith@mail.com", "john_newyork@mail.com" }));
accounts.Add(new List<string>(new string[] { "John", "johnsmith@mail.com", "john00@mail.com" }));
accounts.Add(new List<string>(new string[] { "Mary", "mary@mail.com" }));
accounts.Add(new List<string>(new string[] { "John", "johnnybravo@mail.com" }));
accountsMergeSol.AccountsMerge(accounts);

input = new int[][] {
                new int[] {0, 0},
                new int[] {2, 2},
                new int[] {3, 10},
                new int[] {5, 2},
                new int[] {7, 0}
            };
MinCostConnectPointsSol minCostConnectPointsSol = new MinCostConnectPointsSol();
minCostConnectPointsSol.MinCostConnectPoints(input);

ListNode node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
SwapPairsSol swapPairsSol = new SwapPairsSol();
swapPairsSol.SwapPairs(node);
MergeKListsSol MergeKListsSol = new MergeKListsSol();
ListNode[] lists = new ListNode[]
{
    new ListNode(1, new ListNode(4, new ListNode(5))),
    new ListNode(1, new ListNode(3, new ListNode(4))),
    new ListNode(2, new ListNode(6))
};
MergeKListsSol.MergeKLists(lists);

lists = new ListNode[]
{
    new ListNode(1, new ListNode(2, new ListNode(2))),
    new ListNode(1, new ListNode(1, new ListNode(2)))    
};
MergeKListsSol.MergeKLists(lists);

node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
node = new ListNode(1, new ListNode(2 ));
ReverseKGroupSol reverseK = new ReverseKGroupSol();
reverseK.ReverseKGroup(node, 2);


BuildTreeSol buildTree = new BuildTreeSol();
var preorder = new int[] { 3, 1, 2, 4 };
var inorder = new int[] { 1, 2, 3, 4 };
buildTree.BuildTree(preorder, inorder);

preorder = new int[] { 3, 9, 20, 15, 7 };
inorder = new int[] { 9, 3, 15, 20, 7 };
buildTree.BuildTree(preorder, inorder);

MinimumHeightTrees minimumHeight = new MinimumHeightTrees();
input = new int[][] {
                new int[] {1, 0},
                new int[] {1, 2},
                new int[] {1, 3}                
            };
minimumHeight.FindMinHeightTrees(4, input);


input = new int[][] {
                new int[] {0, 1},
                new int[] {0, 2},
                new int[] {0, 3},
                new int[] {3, 4},
                new int[] {4, 5}
            };
minimumHeight.FindMinHeightTrees(6, input);

input = new int[][] {
                new int[] {3, 0},
                new int[] {3, 1},
                new int[] {3, 2},
                new int[] {3, 4},
                new int[] {5, 4}
            };
minimumHeight.FindMinHeightTrees(6, input);

FindCheapestPriceSol findCheapest = new FindCheapestPriceSol();

input = new int[][] {
                new int[] {0,1,100},
                new int[] {1,2,100},
                new int[] {2,0,100},
                new int[] {1,3,600},
                new int[] { 2, 3, 200 }
            };
findCheapest.FindCheapestPrice(4, input, 0, 3, 1);


input = new int[][] {
                new int[] {3,4,4},
                new int[] {2,5,6},
                new int[] {4,7,10},
                new int[] {9,6,5},
                new int[] {7,4,4},
                new int[] {6,2,10},
                new int[] {6,8,6},
                new int[] {7,9,4},
                new int[] {1,5,4},
                new int[] {1,0,4},
                new int[] {9,7,3},
                new int[] {7,0,5},
                new int[] {6,5,8},
                new int[] {1,7,6},
                new int[] {4,0,9},
                new int[] {5,9,1},
                new int[] {8,7,3},
                new int[] {1,2,6},
                new int[] {4,1,5},
                new int[] {5,2,4},
                new int[] {1,9,1},
                new int[] {7,8,10},
                new int[] {0,4,2},
                new int[] {0,4,2}

            };
findCheapest.FindCheapestPrice(10, input, 6, 0, 7);

TimeMap timeMap = new TimeMap();
timeMap.BinarySearch(new List<int>( new int[] { 10, 20 } ), 15);
timeMap.BinarySearch(new List<int>(new int[] { 10, 20 }), 25);

WordLadder wordLadder = new WordLadder();
wordLadder.LadderLength("hot", "dog", new List<string>() { "hot", "dog", "cog", "pot", "dot"  });

LFUCache lfu = new LFUCache(2);
lfu.Put(1, 1);   // cache=[1,_], cnt(1)=1
lfu.Put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
lfu.Get(1);      // return 1
                 // cache=[1,2], cnt(2)=1, cnt(1)=2
lfu.Put(3, 3);   // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
                 // cache=[3,1], cnt(3)=1, cnt(1)=2
lfu.Get(2);      // return -1 (not found)
lfu.Get(3);      // return 3
                 // cache=[3,1], cnt(3)=2, cnt(1)=2
lfu.Put(4, 4);   // Both 1 and 3 have the same cnt, but 1 is LRU, invalidate 1.
                 // cache=[4,3], cnt(4)=1, cnt(3)=2
lfu.Get(1);      // return -1 (not found)
lfu.Get(3);      // return 3
                 // cache=[3,4], cnt(4)=1, cnt(3)=3
lfu.Get(4);      // return 4
                 // cache=[4,3], cnt(4)=2, cnt(3)=3

lfu = new LFUCache(3);
lfu.Put(1, 1);   // cache=[1,_], cnt(1)=1
lfu.Put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
lfu.Get(2);      // return 1
lfu.Get(1);      // return 1
lfu.Get(2);      // return 1
                 // cache=[1,2], cnt(2)=1, cnt(1)=2
lfu.Put(3, 3);   // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
lfu.Put(4, 4);   // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
                 // cache=[3,1], cnt(3)=1, cnt(1)=2
lfu.Get(3);      // return -1 (not found)
lfu.Get(2);      // return 3
lfu.Get(1);      // return 3
lfu.Get(4);      // return 3

lfu = new LFUCache(0);
lfu.Put(0, 0);   // cache=[1,_], cnt(1)=1
lfu.Get(0);   // cache=[2,1], cnt(2)=1, cnt(1)=1

ContainerWithMostWater container = new ContainerWithMostWater();
container.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 25, 7 });
container.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
container.MaxArea(new int[] { 1,2,1 });

SlidingWindowMaximum slidingWindow = new SlidingWindowMaximum();
slidingWindow.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
slidingWindow.MaxSlidingWindow(new int[] { -7, -8, 7, 5, 7, 1, 6, 0 }, 4);

TrappingRainWater trappingRain = new TrappingRainWater();
trappingRain.Trap(new int[] { 2, 0, 2 });
trappingRain.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });


RomanToInterger RomanToInterger = new RomanToInterger();
RomanToInterger.RomanToInt("LVIII");
RomanToInterger.RomanToInt("MCMXCIV");

EvaluateReversePolishNotation polishNotation = new EvaluateReversePolishNotation();
polishNotation.EvalRPN(new string[] { "2", "1", "+", "3", "*" });
polishNotation.EvalRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" });

DailyTemperaturesSol DailyTemperaturesSol = new DailyTemperaturesSol();
DailyTemperaturesSol.DailyTemperatures(new int[] { 77, 77, 77, 77, 77, 41, 77, 41, 41, 77} );
DailyTemperaturesSol.DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });

LargestRectangleAreaSol LargestRectangleAreaSol = new LargestRectangleAreaSol();
LargestRectangleAreaSol.LargestRectangleArea(new int[] { 5, 4, 1, 2 });
LargestRectangleAreaSol.LargestRectangleArea(new int[] { 4, 2, 0, 3, 2, 5 });
LargestRectangleAreaSol.LargestRectangleArea(new int[] { 3, 6, 5, 7, 4, 8, 1, 0 });

LargestRectangleAreaSol.LargestRectangleArea(new int[] { 4, 2, 0, 3, 2, 5 });
LargestRectangleAreaSol.LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 });

WordBreakSol wordBreak = new WordBreakSol();
wordBreak.WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
    new List<string>(new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }));
wordBreak.WordBreak("catsanddog", new List<string>(new string[] { "cats", "dog", "sand", "and", "cat" }));
wordBreak.WordBreak("catsandog", new List<string> (new string[] { "cats", "dog", "sand", "and", "cat" }));


UpdateMatrixSol updateMatrix = new UpdateMatrixSol();
input = new int[][] {
                new int[] {1, 1, 1},
                new int[] {1, 1, 0},
                new int[] {1, 1, 1}
            };

updateMatrix.UpdateMatrix(input);

input = new int[][] {
                new int[] {0, 0, 0},
                new int[] {0, 1, 0},
                new int[] {1, 1, 1}
            };

updateMatrix.UpdateMatrix(input);

MaximalSquareSol maximalSquare = new MaximalSquareSol();
var matrix= new char[][] {
                new char[] {'1','0','1','0','0'},
                new char[] {'1','0','1','1','1'},
                new char[] {'1','0','1','1','1'},
                new char[] {'1','0','0','1','0'}
            };
maximalSquare.MaximalSquare(matrix);

matrix = new char[][] {
                new char[] {'1','0','1','0','0'},
                new char[] {'1','0','1','1','1'},
                new char[] {'1','0','1','1','1'},
                new char[] {'1','0','1','1','1'}
            };
maximalSquare.MaximalSquare(matrix);

SubsetsSol subsetsSol = new SubsetsSol();
subsetsSol.Subsets(new int[] { 3, 2, 4, 1 });



WordSearch wordSearch = new WordSearch();

matrix = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','C','S'},
                new char[] {'A','D','E','E'}
            };
wordSearch.Exist(matrix, "SEE");


matrix = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','E','S'},
                new char[] {'A','D','E','E'}
            };
wordSearch.Exist(matrix, "ABCESEEEFS");

matrix = new char[][] {
                new char[] {'C','A','A','E'},
                new char[] {'A','A','A','S'},
                new char[] {'B','D','E','E'}
            };
wordSearch.Exist(matrix, "AAB");
matrix = new char[][] {
                new char[] {'A','A'}

            };
wordSearch.Exist(matrix, "AAA");





matrix = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','C','S'},
                new char[] {'A','D','E','E'}
            };
wordSearch.Exist(matrix, "ABCB");

MinimumRoundsSol minimumRounds = new MinimumRoundsSol();
minimumRounds.MinimumRounds(new int[] { 119, 115, 115, 119, 118, 113, 118, 120, 110, 113, 119, 115, 116, 118, 120, 117, 116, 111, 113, 119, 115, 113, 115, 111, 112, 119, 111, 111, 110, 112, 113, 120, 110, 111, 112, 111, 119, 112, 113, 112, 115, 116, 113, 114, 118, 119, 115, 114, 114, 112, 110, 117, 120, 110, 117, 116, 120, 118, 110, 120, 119, 113, 119, 120, 113, 110, 120, 114, 119, 115, 119, 117, 120, 116, 113, 113, 110, 118, 117, 116, 114, 114, 111, 116, 119, 112, 113, 116, 112, 116, 119, 112, 114, 114, 112, 118, 116, 113, 117, 116 });
minimumRounds.MinimumRounds(new int[] { 2, 2, 3, 3, 2, 4, 4, 4, 4, 4 });
minimumRounds.MinimumRounds(new int[] { 2, 3, 3 });

LongestIncreasingSubsequence increasingSubsequence = new LongestIncreasingSubsequence();
increasingSubsequence.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 });
increasingSubsequence.LengthOfLIS(new int[] { 3, 5, 6, 2, 5, 4, 19, 5, 6, 7, 12 });
increasingSubsequence.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
increasingSubsequence.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18, 3, 4 ,5, 6 , 7 , 8, 9 });

NumberOfWaysSol waysSol = new NumberOfWaysSol();
waysSol.NumberOfWays("001101");
// waysSol.NumberOfWays("1111100111101000111101101010000111010100100001011001111100110010111110100001000010110010011010111101001101111101011011110010101010101010101101011011001000111001000101100000011110000000001110101000101010100001111000011011110100111100011011001100000000100111110101110111001011110101100101110001100100010000000110111111100000011001100100111100000110111010101110110101001010100000000101011010101010000111001110111110110100111000101111001111110110000101001010101111000110010111110100111011101101000001011000110101011111110100000110000101111100001101000110001000000101010011101111100101110110110110111100001101111010000010110011101100000011000110011010011100111001000011111110011101001001101101000010111110001101001111001010101000001001000110110100011111111100111000010100110100101001010111101010011110110110001100100101000110111010101000101101110011010000011000110111110000100111101101101101001101000001100111111011110110100110010001011101001000111000011010110010000000001000001011111101001000000110010111110110100000111011001000010100101001101100100100111010100111111010100010010001110000001001001001001110101000101110100101111111001101101100110010101110000111111101110111000100111101001111100000100110101011100000000111001000001000000000110100111100000001010010100100101011001010001001000000010101000010011100101101101011101001111110111101110000101010100011110011010101010011100010100000110100110100000000101110000110000010110011011111100011011101000110110011001010011110111101010010000001001111110010000101000011111111110101111011010010110110001111001010110100001100001100001000000110011011000011101001000001110010011101011110100101101100101100111110100111111111101001010001010001101011000110101000101010100101010011101001010100101000111010001101110111001101101100101100010111100010000101010101111001111000110010110010001101000111010001100100111011100110000101001100101111111100010001000101111110000011100000000101111001001001011101111100010111101010110100001010110111110011000010011110011111101000101001011011010000000001000001010011010101011101011010111101101101010110010000110101010100111111010111010010010101001000110000010111111100110101110011000101010111101100011000100110101100001001111001100101110111111011101001011100110010011101001101111011101001001110110011101101001100101000111010110010101000011100001001001101110101001100010010000010000000000001001100000100101010110111110011011100110000111011001111011111101110001110111000011011110011110101000101010000100011011001100110010001001101011000111101010101010110100000010100011100011010111101110100111110011000001010101101001011010001001100000000100111001011010101011001010001110011110111001010000100001000000100010010000100111110010010010001110010011001011010010101001011110111011001110010110100100001110100110001100110111001011111011111011100101111111110011011100010110000111000010100111111011001001011100100001010110001001001101100000101111100101000011110000011110101010011010110111101101101101100101010101111011100011000011000100110111101010101101010011101000110110010001010011011001010110101111101100001001101000111010101001111101001010100010110010001000010000010001111101000111110101101101110100101101000101000100100100010111100000111111000101001001001001101000111110110101110000010011011100101111000010111011100110000001000100010011011001101001101011101010101010001001110000001101010110101010101111111101111011000100100100010001100100001000101001010010110001010110110001011001001110000000000100100000110110100001011010111111010011011010100101001110000011110100000110011110101110001011111011100010111000001000110011101001011001011111100011111110011010101011000100001110111011100101101101000110001101100111010000010010111101100101110001011010110111011111111001101111111001001101100000001100001001101111011111111111101001000111011100101000011100001000001000110011000111000101000111010011100001010001101010001011100110101010110010101100011101011000111100010011101001000001010010100001101100010010110000110111111001110000011100010101010100001010001011011001100100111100101100000110000001011010111011111111001011010000000010011110100001000100001100010001110100001001111100010101011000110011101001010010010010000001001011001101001101001010101001100111010001111110011010110001110000101100111000110011001011010100001001101011001011010101010011110010101100100010011100001111001010110101001001100111000111101000100100010100000000010101110100011110001010101101100111011001100111101111101100011011010011010010100010000110001110101101100110100100000001100010110101011111010010110101101111101111111001101101111110011011000111001000111010001011100000111000000000001101011100011111010100111111111111111000010100111000100111001011100001110000111001101100111111010000000011100101110000111101000010101110101011000101001010000101101010110111101111111111110111000010000100101111100011000101001101010000100110000111110111001001100011001100011000100101001100110101111000110011101001111110111001101010001010010000111110100010101100011000110100101101011110011000001000000101010010100011100011011001101111101000000110001101001111001001011111100111100000110101010111101001011100101000110001001011100111110011001110100100011001100110001010110110101100100110111100101101110000111011001100111010000000111101010011111100110010001010111111011100110111010111000011010101100010101111000010000010101111000100101110001101101101101110111111100010101000011111111001011010000011111110101110101110100000101100111110110111110010000000011100101001110011101010111101110110100011111000110001110100011000000000110101111010001000110100000110110110000100011100100001100011000011011000010001111011111011101010011101100100100010110000010011110101010100110001100101000111010010011000011000000100010100001100100011001110101110010000000110000110000100011000101011001110001100011110111110000100100100100100100111011000001111011111111110100100110110001010111001011001100011110100110101010001010010000110011000101111110010100001111001101010001101010101100010101100110010111011010011000001100010001100001010111010010110111000001110100100011010101010001011110100100000101011011101000111011001001011100100011111011011100000110111111110100000011000001011100001000110010111000101110101000100010010010100010110110001010100001000000010110000110100000010011011011110111010101100110100111000010011101100100100000010000011010011100001010110100000010111110001101011110000101000011001001111011101111110101000101100000010000100100111001010011100011010100100100001111001001111010111000111111001001011011110110100000000011111100101110100010010100011110100101000011010000011111111011000011110001101011101111000001010000001111101011110001100111011110100001100000000111010100001010010011000101110011001001001111100011011101110001001010110110001001010011111101011100101101111110000000101001110010101100111100100111111111100001101010101110101100101111001001110011100000110010110000101001001001101111100101011100001111111100101101001110111010111010110101001001111100000110010001011011000111001010100010111111111010100100011011010111110000010011100001100101011100001001000000110101111011100101110011000011110111100111101110010100001100000011011101010001111011000001001110001001010001000101000000101100011110100100000101010010011001100011100011000000100100000001110010000011101011010000110001110001");

waysSol.NumberOfWays1("0011010110");
waysSol.NumberOfWays("0011010110");

TriangularSumSol triangularSum = new TriangularSumSol();
triangularSum.TriangularSum(new int[] { 1, 2, 3, 4, 5 });

MinimumKeypressesSol minimumKeypresses = new MinimumKeypressesSol();
minimumKeypresses.MinimumKeypresses("abcdefghijkl");
minimumKeypresses.MinimumKeypresses("apple");

RelativeSortArraySol relativeSortArraySol = new RelativeSortArraySol();
relativeSortArraySol.RelativeSortArray(new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new int[] { 2, 1, 4, 3, 9, 6 });

NumRollsToTargetSol numRolls = new NumRollsToTargetSol();
numRolls.NumRollsToTarget(30, 30, 500);
numRolls.NumRollsToTarget(2, 6, 3);
numRolls.NumRollsToTarget(2, 6, 7);
numRolls.NumRollsToTarget(1, 6, 3);

LargestVarianceSol largestVarianceSol = new LargestVarianceSol();
largestVarianceSol.LargestVariance("aababbb");
largestVarianceSol.LargestVariance("dsyemilsuwhciclqwprizywgkwkbgcqhtcwfvlw");
largestVarianceSol.LargestVariance("abcde");

PlatesBetweenCandlesSol platesBetweenCandlesSol = new PlatesBetweenCandlesSol();
input = new int[][] {
                new int[] {2, 5},
                new int[] {5, 9}
            };
platesBetweenCandlesSol.PlatesBetweenCandles("**|**|***|", input);
input = new int[][] {
                new int[] {2, 2}
            };
platesBetweenCandlesSol.PlatesBetweenCandles("***", input);

MinimumSwapsSol minimumSwaps = new MinimumSwapsSol();
minimumSwaps.MinimumSwaps(new int[] { 35, 25, 30, 25, 31, 39, 35 });
minimumSwaps.MinimumSwaps(new int[] { 9 });
minimumSwaps.MinimumSwaps(new int[] { 3, 4, 5, 5, 3, 1 });

ThreeSumSol threeSumSol = new ThreeSumSol();
threeSumSol.ThreeSum(new int[] { -2, 0, 1, 1, 2 });
threeSumSol.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4  });
threeSumSol.ThreeSum(new int[] { 0, 1, 1 });
threeSumSol.ThreeSum(new int[] { 0, 0, 0 });

FindAllConcatenatedWordsInADictSol findAllConcatenatedWordsInADictSol = new FindAllConcatenatedWordsInADictSol();
findAllConcatenatedWordsInADictSol.FindAllConcatenatedWordsInADict(new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" });

ReorganizeStringSol reorganizeStringSol = new ReorganizeStringSol();
reorganizeStringSol.ReorganizeString("cxmwmmm");
reorganizeStringSol.ReorganizeString("aab");
reorganizeStringSol.ReorganizeString("aaabc");

WordBreakII wordBreak2 = new WordBreakII();
wordBreak2.WordBreak("catsanddog", new List<string> { "cat", "cats", "and", "sand", "dog" });

EarliestFullBloomSol earliestFullBloomSol = new EarliestFullBloomSol();
earliestFullBloomSol.EarliestFullBloom(new int[] { 27, 5, 24, 17, 27, 4, 23, 16, 6, 26, 13, 17, 21, 3, 9, 10, 28, 26, 4, 10, 28, 2 }, new int[] { 26, 9, 14, 17, 6, 14, 23, 24, 11, 6, 27, 14, 13, 1, 15, 5, 12, 15, 23, 27, 28, 12 });
earliestFullBloomSol.EarliestFullBloom(new int[] { 1, 4, 3 }, new int[] { 2, 3, 1 });
earliestFullBloomSol.EarliestFullBloom(new int[] { 1, 2, 3, 2 }, new int[] { 2, 1, 2, 1 });

SmallestRangeCoverage smallestRange = new SmallestRangeCoverage();
List<IList<int>> vs = new List<IList<int>>();
// [[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]
vs.Add(new List<int>(new int[] { 4, 10, 15, 24, 26 }));
vs.Add(new List<int>(new int[] { 0, 9, 12, 20 }));
vs.Add(new List<int>(new int[] { 5, 18, 22, 30 }));
smallestRange.SmallestRange(vs);

vs = new List<IList<int>>();
// [[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]
vs.Add(new List<int>(new int[] { 1, 2, 3 }));
vs.Add(new List<int>(new int[] { 1, 2, 3 }));
vs.Add(new List<int>(new int[] { 1, 2, 3 }));
smallestRange.SmallestRange(vs);

GasStation gasStation = new GasStation();
gasStation.CanCompleteCircuit(new int[] { 0,0,0,0,2 }, new int[] { 0, 0, 0, 1, 0 });
gasStation.CanCompleteCircuit(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 });

LongestCommonSubsequenceSol longestCommon = new LongestCommonSubsequenceSol();
longestCommon.LongestCommonSubsequence("ace", "abcde");
longestCommon.LongestCommonSubsequence("zelohidwdcxilkvytazgfozonwrkbalcpizgtmzuhkbsfefshmtctuvc", "rwjmzoncvihmlmvgdujopwrajuxmjefonivyvkncnwnkjaxkritkporsj");
longestCommon.LongestCommonSubsequence("hofubmnylkra", "pqhgxgdofcvmr");
longestCommon.LongestCommonSubsequence("ezupkr", "ubmrapg"); 
longestCommon.LongestCommonSubsequence("bl", "yby");

JumpGame jumpGame = new JumpGame();
jumpGame.CanJump(new int [] { 2, 3, 1, 1, 4 });
jumpGame.CanJump(new int[] { 3, 2, 1, 0, 4 });

MatrixLongestIncreasingPath matrixLongest = new MatrixLongestIncreasingPath();
input = new int[][] {
                new int[] {9,9,4},
                new int[] { 6, 6, 8 },
                new int[] { 2, 1, 1 }
            };
matrixLongest.LongestIncreasingPath(input);

LongestValidParenthesesSol longestValid = new LongestValidParenthesesSol();
longestValid.LongestValidParentheses("()()");
longestValid.LongestValidParentheses("()(()");
longestValid.LongestValidParentheses("((())");

FindMinSol findMin = new FindMinSol();

findMin.FindMin(new int[] { 3, 4, 5, 1, 2 });
findMin.FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 });
findMin.FindMin(new int[] { 11, 13, 15, 17 });

FindClosestElementsSol findClosestElements = new FindClosestElementsSol();
findClosestElements.FindClosestElements(new int[] { 1, 3 }, 1, 2);
findClosestElements.FindClosestElements(new int[] { 1, 25, 35, 45, 50, 59 }, 1, 30);
findClosestElements.FindClosestElements(new int[] { 0, 0, 1, 2, 3, 3, 4, 7, 7, 8 }, 3, 5);
findClosestElements.FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 3);
findClosestElements.FindClosestElements(new int[] { 1, 1, 1, 10, 10, 10 }, 1, 9);
findClosestElements.FindClosestElements(new int[] { 1, 2, 5, 5, 6, 6, 7, 7, 8, 9 }, 7, 7);

KokoEatingBananas kokoEating = new KokoEatingBananas();
kokoEating.MinEatingSpeed(new int[] { 805306368, 805306368, 805306368 }, 1000000000);
kokoEating.MinEatingSpeed(new int[] { 1, 1, 1, 999999999 }, 10);
kokoEating.MinEatingSpeed(new int[] { 873375536, 395271806, 617254718, 970525912, 634754347, 824202576, 694181619, 20191396, 886462834, 442389139, 572655464, 438946009, 791566709, 776244944, 694340852, 419438893, 784015530, 588954527, 282060288, 269101141, 499386849, 846936808, 92389214, 385055341, 56742915, 803341674, 837907634, 728867715, 20958651, 167651719, 345626668, 701905050, 932332403, 572486583, 603363649, 967330688, 484233747, 859566856, 446838995, 375409782, 220949961, 72860128, 998899684, 615754807, 383344277, 36322529, 154308670, 335291837, 927055440, 28020467, 558059248, 999492426, 991026255, 30205761, 884639109, 61689648, 742973721, 395173120, 38459914, 705636911, 30019578, 968014413, 126489328, 738983100, 793184186, 871576545, 768870427,
    955396670, 328003949, 786890382, 450361695, 994581348, 158169007, 309034664, 388541713, 142633427, 390169457, 161995664, 906356894, 379954831, 448138536 }, 943223529);
kokoEating.MinEatingSpeed(new int[] { 332484035, 524908576, 855865114, 632922376, 222257295, 690155293, 112677673, 679580077, 337406589, 290818316, 877337160, 901728858, 679284947,
    688210097, 692137887, 718203285, 629455728, 941802184 }, 823855818);



kokoEating.MinEatingSpeed(new int[] { 30, 11, 23, 4, 20 }, 5);
kokoEating.MinEatingSpeed(new int[] { 312884470 }, 312884469);

kokoEating.MinEatingSpeed(new int[] { 3, 6, 7, 11 }, 8);
kokoEating.MinEatingSpeed(new int[] { 30, 11, 23, 4, 20 }, 6);

SudokuSolver sudokuSolver = new SudokuSolver();
matrix = new char[][] {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };
sudokuSolver.SolveSudoku(matrix);

WizardsTotalStrength totalStrength = new WizardsTotalStrength();
totalStrength.TotalStrength(new int[] { 5, 6, 12});
totalStrength.TotalStrength(new int[] { 1, 3, 1, 2 });
totalStrength.TotalStrength(new int[] { 747, 812, 112, 1230, 1426, 1477, 1388, 976, 849, 1431, 1885, 
    1845, 1070, 1980, 280, 1075, 232, 1330, 1868, 1696, 1361, 1822, 524, 1899, 1904, 538, 731, 985,
    279, 1608, 1558, 930, 1232, 1497, 875, 1850, 1173, 805, 1720, 33, 233, 330, 1429, 
    1688, 281, 362, 1963, 927, 1688, 256, 1594, 1823, 743, 553, 1633, 1898, 1101, 1278, 717, 522, 1926, 
    1451, 119, 1283, 1016, 194, 780, 1436, 1233, 710, 1608, 523, 874, 1779, 1822, 134, 1984 });
totalStrength.TotalStrength(new int[] { 5, 4, 6 });

MaximumBooksSol maximumBooks = new MaximumBooksSol();

maximumBooks.MaximumBooks(new int[] { 13, 2, 11, 11, 1, 4, 8, 20 });
maximumBooks.MaximumBooks(new int[] { 1, 2, 3, 9, 8, 7, 6 });
maximumBooks.MaximumBooks(new int[] { 5, 5, 5 });

maximumBooks.MaximumBooks(new int[] { 2, 4, 5 });
maximumBooks.MaximumBooks(new int[] { 8, 5, 2, 7, 9 });
maximumBooks.MaximumBooks(new int[] { 8, 2, 3, 7, 3, 4, 0, 1, 4, 3 });
maximumBooks.MaximumBooks(new int[] { 7, 0, 3, 4, 5 });

Codec codec = new Codec();
var str = codec.serialize(new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5))));
var outNode = codec.deserialize(str);

MinMovesSol minMoves = new MinMovesSol();
minMoves.MinMoves(new int[] { 83, 86, 77, 15, 93, 35, 86, 92, 49, 21 });
minMoves.MinMoves(new int[] { 5, 6, 8, 8, 5 });
minMoves.MinMoves(new int[] { 1, 1000000 });
minMoves.MinMoves(new int[] { 1, 2, 3 });
minMoves.MinMoves(new int[] { 1, 1, 1 });

SearchRotatedArray searchRotatedArray = new SearchRotatedArray();
searchRotatedArray.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 2);
searchRotatedArray.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
searchRotatedArray.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
searchRotatedArray.Search(new int[] { 2, 4, 5, 6, 7, 0, 1 }, 0);
searchRotatedArray.Search(new int[] { 6, 7, 0, 1, 2, 4, 5 }, 0);

SumSubarrayMinsSol sumSubarray = new SumSubarrayMinsSol();
sumSubarray.SumSubarrayMins(new int[] { 3, 1, 2, 4 });
sumSubarray.SumSubarrayMins(new int[] { 19, 19, 62, 66 });

FindKthLargestSol findKth = new FindKthLargestSol();
findKth.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 5);
findKth.FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2);

MyAtoiSol myAtoi = new MyAtoiSol();
myAtoi.MyAtoi("20000000000000000000");
myAtoi.MyAtoi("  -42");
myAtoi.MyAtoi("4193 with words");

MaximalNetworkRankSol2 rankSol2 = new MaximalNetworkRankSol2();
input = new int[][] {
                new int[] {2, 4}
            };
rankSol2.MaximalNetworkRank(6, input);

input = new int[][] {
                new int[] {0, 1},
                new int[] {0, 3},
                new int[] {1, 2},
                new int[] {1, 3}
               
            };
rankSol2.MaximalNetworkRank(4, input);

input = new int[][] {
                new int[] {0, 1},
                new int[] {0, 3},
                new int[] {1, 2},
                new int[] {1, 3},
                new int[] {2, 3},
                new int[] {2, 4}

            };
rankSol2.MaximalNetworkRank(5, input);

LongestPathSol longestPath = new LongestPathSol();
longestPath.LongestPath(new int[] { -1, 0, 0, 1, 1, 2 }, "abacbe");
longestPath.LongestPath(new int[] { -1, 0, 1 }, "abb");
longestPath.LongestPath(new int[] { -1, 137, 65, 60, 73, 138, 81, 17, 45, 163, 145, 99, 29, 162, 19, 20, 132, 132, 13, 60, 21, 18, 155, 65, 13, 163, 125, 102, 96, 60, 50, 101, 100, 86, 162, 42, 162, 94, 21, 56, 45, 56, 13, 23, 101, 76, 57, 89, 4, 161, 16, 139, 29, 60, 44, 127, 19, 68, 71, 55, 13, 36, 148, 129, 75, 41, 107, 91, 52, 42, 93, 85, 125, 89, 132, 13, 141, 21, 152, 21, 79, 160, 130, 103, 46, 65, 71, 33, 129, 0, 19, 148, 65, 125, 41, 38, 104, 115, 130, 164, 138, 108, 65, 31, 13, 60, 29, 116, 
    26, 58, 118, 10, 138, 14, 28, 91, 60, 47, 2, 149, 99, 28, 154, 71, 96, 60, 106, 79, 129, 83, 42, 102, 34, 41, 55, 31, 
    154, 26, 34, 127, 42, 133, 113, 125, 113, 13, 54, 132, 13, 56, 13, 42, 102, 135, 130, 75, 25, 80, 159, 39, 29, 41, 89, 85, 19 }, "ajunvefrdrpgxltugqqrwisyfwwtldxjgaxsbbkhvuqeoigqssefoyngykgtthpzvsxgxrqedntvsjcpdnupvqtroxmbpsdwoswxfarnixkvcimzgvrevxnxtkkovwxcjmtgqrrsqyshxbfxptuvqrytctujnzzydhpal");


longestPath.LongestPath(new int[] { -1, 0, 1 }, "aab");
longestPath.LongestPath(new int[] { -1, 0, 0, 0 }, "aabc");

longestPath.LongestPath(new int[] { -1, 0, 0, 1, 1, 2, 3 }, "abacbef");

MissingRollsSol missingRolls = new MissingRollsSol();
missingRolls.MissingRolls(new int[] { 1, 5, 6 }, 3, 4);
missingRolls.MissingRolls(new int[] { 3, 2, 4, 3 }, 4, 2);
missingRolls.MissingRolls(new int[] { 1, 3, 6, 4, 1, 2, 1, 5, 5, 4 }, 6, 10);


missingRolls.MissingRolls(new int[] { 1, 2, 3, 4 }, 6, 4);


RegExMatching regExMatch = new RegExMatching();
regExMatch.IsMatch("ab", ".*..c*");
regExMatch.IsMatch("ab", ".*..");
regExMatch.IsMatch("aaa", "ab*a*c*aaa");
regExMatch.IsMatch("aaa", "ab*a*c*aaac");
regExMatch.IsMatch("aa", "a*");
regExMatch.IsMatch("aaa", "a*a");
regExMatch.IsMatch("ab", ".*c");
regExMatch.IsMatch("ab", ".*");

regExMatch.IsMatch("ab", ".*b");
regExMatch.IsMatch("aa", "a");
regExMatch.IsMatch("aaa", "a*");
regExMatch.IsMatch("aab", "c*a*b");

MaxLengthSol maxLength = new MaxLengthSol();
maxLength.MaxLength(new List<string> { "un", "iq", "ue" });
maxLength.MaxLength(new List<string> { "cha", "r", "act", "ers" });

MaxChunksToSortedSol maxChunksToSorted = new MaxChunksToSortedSol();
maxChunksToSorted.MaxChunksToSorted(new int[] { 1, 1, 0, 0, 1 });

SpiralMatrixIIISol spiralMatrix = new SpiralMatrixIIISol();
spiralMatrix.SpiralMatrixIII(5, 6, 1, 4);

UniquePathsIIISol uniquePaths = new UniquePathsIIISol();
input = new int[][] {
                new int[] {1,0,0,0},
                new int[] {0,0,0,0},
                new int[] {0,0,2,-1}
            };
uniquePaths.UniquePathsIII(input);
input = new int[][] {
                new int[] {1,-1,2}
               
            };
uniquePaths.UniquePathsIII(input);

NumsSameConsecDiffSol numSameConsecDiff = new NumsSameConsecDiffSol();
numSameConsecDiff.NumsSameConsecDiff(3, 7 );

LongestArithSeqLengthSol LongestArithSeqLengthSol = new LongestArithSeqLengthSol();
LongestArithSeqLengthSol.LongestArithSeqLength(new int[] { 24, 13, 1, 100, 0, 94, 3, 0, 3 });
LongestArithSeqLengthSol.LongestArithSeqLength(new int[] { 20, 1, 15, 3, 10, 5, 8 });

MinimumDifferenceSol MinimumDifferenceSol = new MinimumDifferenceSol();
MinimumDifferenceSol.MinimumDifference(new int[] { 3, 9, 16, 3 });
MinimumDifferenceSol.MinimumDifference(new int[] { 2, -1, 0, 4, -2, -9 });

//MinimumDifferenceSol.MinimumDifference(new int[] { 7772197, 4460211, -7641449, -8856364, 546755, -3673029, 527497, -9392076, 3130315, -5309187, -4781283, 5919119, 
//    3093450, 1132720, 6380128, -3954678, -1651499, -7944388, -3056827, 1610628, 7711173, 6595873, 302974, 7656726, -2572679, 0, 2121026, -5743797, -8897395, -9699694 });
MinimumDifferenceSol.MinimumDifference(new int[] { 3, 9, 7, 3 });
MinimumDifferenceSol.MinimumDifference(new int[] { 2, -1, 0, 4, -2, -9 });
MinTimeToCollectApple MinTimeToCollectApple = new MinTimeToCollectApple();
input = new int[][] {
                new int[] {0, 1},
                new int[] {0, 2},
                new int[] {1, 4},
                new int[] {1, 5},
                new int[] {2, 3},
                new int[] {2, 6}
            };
MinTimeToCollectApple.MinTime(7, input, new List<bool> { false, false, true, false, true, true, false });

input = new int[][] {
                new int[] {0, 2},
                new int[] {0, 3},
                new int[] {1, 2}
            };
MinTimeToCollectApple.MinTime(4, input, new List<bool> { false, true, false, false });

ShortestPathSol ShortestPathSol = new ShortestPathSol();
input = new int[][] {
                new int[] {0,0,0},
                new int[] { 1,1,0 },
                new int[] { 0, 0, 0 },
                new int[] { 0,1,1 },
                new int[] { 0, 0, 0 }
            };
ShortestPathSol.ShortestPath(input, 1);

InsertInterval insertInterval = new InsertInterval();

input = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 5 },
                new int[] { 6, 7 },
                new int[] { 8, 10 },
                new int[] { 12, 16 }
            };
insertInterval.Insert(input, new int[] { 4, 8 });

input = new int[][] {
                new int[] { 1, 3 },
                new int[] { 6, 9 }
            };
insertInterval.Insert(input, new int [] { 2, 5 });

MaxProductSol maxProduct = new MaxProductSol();
maxProduct.MaxProduct(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6))));

MinFlipsMonoIncrSol minFlips = new MinFlipsMonoIncrSol();
minFlips.MinFlipsMonoIncr("10011111110010111011");

