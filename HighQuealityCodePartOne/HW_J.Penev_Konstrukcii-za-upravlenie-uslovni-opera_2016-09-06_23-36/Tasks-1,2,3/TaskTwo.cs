// First if statement
Potato potato;

bool IsPotatoExist = (potato != null);
bool IsPotatoReadyForCook = (potato.HasBeenPeeled && !potato.IsRotten);

if (IsPotatoExist && IsPotatoReadyForCook)
	{
     Cook(potato);
	}


// Second if statement
var isyBetweenMinAndMaxY = (y >= MIN_Y && y <= MAX_Y);
var isxBetweenMinAndMaxX = (x >= MIN_X && x <= MAX_X);
var isIndexValid = (isyBetweenMinAndMaxY && isxBetweenMinAndMaxX && !shouldNotVisitCell);

if (isIndexValid)
{
   VisitCell();
}