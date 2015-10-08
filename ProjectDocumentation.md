
High-Quality Programming Code – Team Projects
=============================================
This is the documentation of project "Balloons-Pop-7"


1. Repository structure is initially changed, code is briefly formatted in order to be more readable. 

  private static bool IsLegalMove(int i, int j)
         {
             if ((i < 0) || (j < 0) || (j > length - 1) || (i > shirina - 1)) return false;
             else return (_t[i, j] != ".");
	}

 private static bool IsLegalMove(int i, int j)
         {
            if ((i < 0) || (j < 0) || (j > length - 1) || (i > shirina - 1))
                return false;
            else
                return (_t[i, j] != ".");
         }

2. Variables and methods are named better, the goal is self - documented code.

 const int shirina = 5;
 const int length = 10;

 const int WIDTH = 5;
 const int HEIGHT = 10;