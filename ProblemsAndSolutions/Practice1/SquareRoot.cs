using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Google
{
    public class SquareRoot
    {
        public static long FindBruteForce(int x)
        {
            if( x < 0)
            {
                throw new ArgumentException();
            }

            if(x <= 1)
            {
                return x; 
            }
            BigInteger ans = 0;
            BigInteger min = 0, max = x, mid;

            mid = max / 2;

            for(int i = 1; i<=mid; i++)
            {
                BigInteger item = i * i; 

                if(item > x)
                {
                    return i - 1;
                }
                else if(item == x)
                {
                    return i;
                }
            }

            return (int)mid;

        }

        public static int FindBinarySearch(int x)
        {
            if (x <= 1)
            {
                return x;
            }
            BigInteger ans = 0;
            BigInteger min = 0, max = x, mid;

            while (min <= max)
            {
                mid = (min + max) / 2;
                if (mid * mid == x)
                {
                    ans = mid; break;
                }
                if (mid * mid < x)
                {
                    min = mid + 1; ans = mid;
                }
                else max = mid - 1;
            }
            int num = (int)ans;
            return num;
        }
    }


    public class TreeClass
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;
            root.right = left;

            return root;
        }


        public bool IsSame(TreeNode q, TreeNode p)
        {
            if(q == null && p == null)
            {
                return true;
            }

            if(q!=null || p != null)
            {
                return false; 
            }


            bool left = IsSame(q.left, p.left);
            bool right = IsSame(q.right, p.right);

            return left && right && p.val == q.val; 
        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

    }
}
