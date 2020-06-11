#if(0)
int main()
{
	cout << "\n";
}
#endif
#if(0)
int jumpingOnClouds(vector<int> c, int k)
{
	int n = c.size();
	int e = 100;
	int i = 0;
	while (true)
	{
		e--;
		i += k;
		if (i >= n)
		{
			i -= n;
		}
		if (c[i] == 1)
		{
			e -= 2;
		}
		if (i == 0)
		{
			break;
		}
	}
	return e;
}

int main()
{
	vector<int> c{ 0, 0, 1, 0, 0, 1, 1, 0 };
	int result = jumpingOnClouds(c, 2);
	cout << result << "\n";
}
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
#if(0)
#endif
