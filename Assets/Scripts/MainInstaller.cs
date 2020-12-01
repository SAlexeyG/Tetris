using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
	[SerializeField] private float fallTime = default;
	[SerializeField] private GameObject[] tetrominos = default;
	[SerializeField] private Vector3 spawnPoint = default;
	[SerializeField] private FieldSize fieldSize = default;

	public override void InstallBindings()
	{
		Container.Bind<float>().FromInstance(fallTime).NonLazy();
		Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();

		Container.Bind<GameObject[]>().FromInstance(tetrominos).NonLazy();
		Container.Bind<Vector3>().FromInstance(spawnPoint).NonLazy();
		Container.Bind<ITetrominoSpawner>().To<TetrominoSpawner>().AsSingle().NonLazy();

		Container.Bind<FieldSize>().FromInstance(fieldSize);
		Container.Bind<IField>().To<Field>().AsSingle().NonLazy();
	}
}