using System;

interface IActor
{
	public List<Point> placement { get; set; }
	int area { get; }

	public void setPlacement(List<Point> new_placement)
	{
		this.placement = new_placement;
	}

	public void getPlacement()
    {
		return this.placement;
    }
}
