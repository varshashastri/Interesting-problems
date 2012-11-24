#include<stdio.h>
void subset(int n,int d,int w[])
{
	int s,k,i,x[10];
	for(i=1;i<=n;i++)
		x[i]=0;
	s=0,k=1;
	x[k]=1;
	while(1)
	{
		if(k<=n&&x[k]==1)
		{
			if(s+w[k]==d)
			{
				printf("\nsolution is");
				for(i=1;i<=n;i++)
				{
					if(x[i]==1)
						printf("%d",w[i]);
				}
				printf("\n");
				x[k]=0;
			}
			else if(s+w[k]<d)
			{
				s+=w[k];
			}
			else
			{
				x[k]=0;
			}
		}
		else
		{
			k--;
			while(k>0&&x[k]==0)
				k--;
			if(k==0)
				break;
			x[k]=0;
			s=s-w[k];
		}
		k=k+1;
		x[k]=1;
	}
}

int main()
{
	int n,i,d,w[10];
	printf("enter the value of n");
	scanf("%d",&n);
	printf("enter the set in increasing order");
	for(i=1;i<=n;i++)
		scanf("%d",&w[i]);
	printf("enter the max subset value");
	scanf("%d",&d);
	subset(n,d,w);
}
