using Godot;
using System;
public partial class PlayerController : CharacterBody2D
{
	[Export]
	public int speed { get; set; } = 400;
	[Export]
	public float rotationSpeed { get; set; } = 20.5f;

	Vector2 inputDirection;
	Vector2 rotationDirection;


	public void GetInput()
	{
		inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * speed;
		rotationDirection = new Vector2(-inputDirection.Y, inputDirection.X);
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		if (rotationDirection.LengthSquared() > 0)
		{
			float targetAngle = rotationDirection.Angle();
			Rotation = Mathf.LerpAngle(Rotation, targetAngle, rotationSpeed * (float)delta);
		}
		MoveAndSlide();
	}
}
